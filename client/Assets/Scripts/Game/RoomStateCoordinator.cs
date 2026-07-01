using UnityEngine;

public class RoomStateCoordinator : MonoBehaviour
{
    [SerializeField] private StatusDisplay statusDisplay;
    [SerializeField] private string openingObjective = "Find the clue.";

    private void Awake()
    {
        if (statusDisplay == null)
        {
            statusDisplay = FindFirstObjectByType<StatusDisplay>();
        }
    }

    private void Start()
    {
        statusDisplay?.SetStatus(openingObjective);
    }
}
