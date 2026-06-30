using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private StatusDisplay statusDisplay;
    [SerializeField] private LocalSaveStore saveStore;
    [SerializeField] private string idleMessage = "Find something useful.";
    [SerializeField] private string readyMessage = "Press E to inspect.";

    private IInteractable currentTarget;

    private void Awake()
    {
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
        statusDisplay?.SetStatus(idleMessage);
    }

    private void Update()
    {
        if (currentTarget != null && Input.GetKeyDown(KeyCode.E))
        {
            string message = currentTarget.Interact();
            saveStore?.SaveCheckpoint("first-room", transform.position);
            statusDisplay?.SetStatus(message);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            currentTarget = interactable;
            statusDisplay?.SetStatus(readyMessage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable) && currentTarget == interactable)
        {
            currentTarget = null;
            statusDisplay?.SetStatus(idleMessage);
        }
    }
}
