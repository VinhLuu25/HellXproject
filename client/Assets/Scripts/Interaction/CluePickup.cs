using System;
using UnityEngine;

public class CluePickup : MonoBehaviour, IInteractable
{
    [SerializeField] private ClueData clue = new ClueData
    {
        clueId = "chapel-note",
        inventoryItemId = "torn-note",
        journalEntryId = "chapel-note-entry",
        foundMessage = "Clue found: a torn chapel note."
    };

    [SerializeField] private bool hideAfterPickup = true;

    private InventoryState inventory;
    private JournalState journal;
    private bool collected;

    public bool IsCollected => collected;

    private void Awake()
    {
        inventory = FindFirstObjectByType<InventoryState>();
        journal = FindFirstObjectByType<JournalState>();
    }

    public string Interact()
    {
        if (collected)
        {
            return clue.foundMessage;
        }

        collected = true;
        inventory?.AddItem(clue.inventoryItemId);
        journal?.AddEntry(clue.journalEntryId);

        if (hideAfterPickup)
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                sprite.enabled = false;
            }
        }

        return clue.foundMessage;
    }
}

[Serializable]
public class ClueData
{
    public string clueId;
    public string inventoryItemId;
    public string journalEntryId;
    public string foundMessage;
}
