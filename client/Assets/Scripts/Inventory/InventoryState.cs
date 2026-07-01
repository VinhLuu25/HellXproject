using System.Collections.Generic;
using UnityEngine;

public class InventoryState : MonoBehaviour
{
    private readonly HashSet<string> items = new HashSet<string>();

    public IReadOnlyCollection<string> Items => items;

    public bool HasItem(string itemId)
    {
        return items.Contains(itemId);
    }

    public void AddItem(string itemId)
    {
        if (!string.IsNullOrWhiteSpace(itemId))
        {
            items.Add(itemId);
        }
    }
}
