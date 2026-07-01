using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField] private string checkpointId = "room-exit-checkpoint";
    [SerializeField] private string reachedMessage = "Checkpoint saved.";
    [SerializeField] private SavePayloadBuilder payloadBuilder;
    [SerializeField] private LocalSaveStore saveStore;
    [SerializeField] private StatusDisplay statusDisplay;

    private bool reached;

    private void Awake()
    {
        if (payloadBuilder == null)
        {
            payloadBuilder = FindFirstObjectByType<SavePayloadBuilder>();
        }

        if (saveStore == null)
        {
            saveStore = FindFirstObjectByType<LocalSaveStore>();
        }

        if (statusDisplay == null)
        {
            statusDisplay = FindFirstObjectByType<StatusDisplay>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (reached || other.GetComponent<PlayerMovement>() == null)
        {
            return;
        }

        reached = true;
        SavePayload payload = payloadBuilder != null
            ? payloadBuilder.Build(checkpointId, other.transform.position)
            : SavePayloadBuilder.BuildFallback(checkpointId, other.transform.position);

        saveStore?.SaveCheckpoint(payload);
        statusDisplay?.SetStatus(reachedMessage);
    }
}
