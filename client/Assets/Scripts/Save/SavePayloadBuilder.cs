using System;
using System.Linq;
using UnityEngine;

public class SavePayloadBuilder : MonoBehaviour
{
    [SerializeField] private string currentChapter = "chapter-01";
    [SerializeField] private string currentRoom = "first-room";
    [SerializeField] private InventoryState inventory;
    [SerializeField] private JournalState journal;
    [SerializeField] private PuzzleState puzzleState;

    private void Awake()
    {
        if (inventory == null)
        {
            inventory = FindFirstObjectByType<InventoryState>();
        }

        if (journal == null)
        {
            journal = FindFirstObjectByType<JournalState>();
        }

        if (puzzleState == null)
        {
            puzzleState = FindFirstObjectByType<PuzzleState>();
        }
    }

    public SavePayload Build(string checkpointId, Vector2 playerPosition)
    {
        SavePayload payload = BuildFallback(checkpointId, playerPosition);
        payload.currentChapter = currentChapter;
        payload.currentRoom = currentRoom;
        payload.inventoryItems = inventory != null ? inventory.Items.ToArray() : Array.Empty<string>();
        payload.journalEntries = journal != null ? journal.Entries.ToArray() : Array.Empty<string>();
        payload.puzzleFlags = puzzleState != null ? puzzleState.SolvedPuzzles.ToArray() : Array.Empty<string>();
        payload.collectedClues = FindObjectsByType<CluePickup>(FindObjectsInactive.Include, FindObjectsSortMode.None)
            .Where(clue => clue.IsCollected)
            .Select(clue => clue.gameObject.name)
            .ToArray();
        return payload;
    }

    public static SavePayload BuildFallback(string checkpointId, Vector2 playerPosition)
    {
        return new SavePayload
        {
            currentChapter = "chapter-01",
            currentRoom = "first-room",
            checkpointId = checkpointId,
            collectedClues = Array.Empty<string>(),
            inventoryItems = Array.Empty<string>(),
            journalEntries = Array.Empty<string>(),
            puzzleFlags = Array.Empty<string>(),
            playerPosition = new SaveVector2
            {
                x = playerPosition.x,
                y = playerPosition.y
            },
            savedAt = DateTime.UtcNow.ToString("O")
        };
    }
}

[Serializable]
public class SavePayload
{
    public string currentChapter;
    public string currentRoom;
    public string checkpointId;
    public string[] collectedClues;
    public string[] inventoryItems;
    public string[] journalEntries;
    public string[] puzzleFlags;
    public SaveVector2 playerPosition;
    public string savedAt;
}

[Serializable]
public class SaveVector2
{
    public float x;
    public float y;
}
