using System.Collections;
using UnityEngine;

public class BackendStatusController : MonoBehaviour
{
    [SerializeField] private BackendClient backendClient;
    [SerializeField] private StatusDisplay statusDisplay;
    [SerializeField] private LocalSaveStore saveStore;
    [SerializeField] private bool connectOnStart = false;

    private void Awake()
    {
        if (backendClient == null)
        {
            backendClient = FindFirstObjectByType<BackendClient>();
        }

        if (statusDisplay == null)
        {
            statusDisplay = FindFirstObjectByType<StatusDisplay>();
        }

        if (saveStore == null)
        {
            saveStore = FindFirstObjectByType<LocalSaveStore>();
        }
    }

    private void Start()
    {
        if (connectOnStart)
        {
            CheckBackend();
        }
    }

    public void CheckBackend()
    {
        StartCoroutine(RunMockFlow());
    }

    private IEnumerator RunMockFlow()
    {
        statusDisplay?.SetStatus("Checking backend...");

        BackendResult<BackendHealthResponse> health = null;
        yield return backendClient.GetHealth(result => health = result);

        if (health == null || !health.IsSuccess || health.Value.status != "ok")
        {
            statusDisplay?.SetStatus($"Backend unavailable: {health?.Error ?? "no response"}");
            yield break;
        }

        BackendResult<BackendSessionResponse> session = null;
        yield return backendClient.StartTestSession(result => session = result);

        if (session == null || !session.IsSuccess)
        {
            statusDisplay?.SetStatus($"Session failed: {session?.Error ?? "no response"}");
            yield break;
        }

        BackendResult<BackendSaveResponse> save = null;
        yield return backendClient.LoadCurrentSave(result => save = result);

        if (save == null || !save.IsSuccess)
        {
            statusDisplay?.SetStatus($"Save load failed: {save?.Error ?? "no response"}");
            yield break;
        }

        saveStore?.SaveBackendSnapshot(save.RawJson);
        statusDisplay?.SetStatus($"Backend ready: {save.Value.currentRoom} / {save.Value.checkpointId}");
    }
}
