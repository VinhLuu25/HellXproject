using UnityEngine;

public class PuzzleInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string puzzleId = "chapel-lock";
    [SerializeField] private string requiredInventoryItemId = "torn-note";
    [SerializeField] private string missingMessage = "The lock needs the torn chapel note.";
    [SerializeField] private string solvedMessage = "The chapel lock opens.";
    [SerializeField] private string alreadySolvedMessage = "The chapel lock is already open.";

    private InventoryState inventory;
    private PuzzleState puzzleState;

    public string PuzzleId => puzzleId;
    public bool IsSolved => puzzleState != null && puzzleState.IsSolved(puzzleId);

    private void Awake()
    {
        inventory = FindFirstObjectByType<InventoryState>();
        puzzleState = FindFirstObjectByType<PuzzleState>();
    }

    public string Interact()
    {
        if (puzzleState != null && puzzleState.IsSolved(puzzleId))
        {
            return alreadySolvedMessage;
        }

        if (inventory == null || !inventory.HasItem(requiredInventoryItemId))
        {
            return missingMessage;
        }

        puzzleState?.MarkSolved(puzzleId);
        return solvedMessage;
    }
}
