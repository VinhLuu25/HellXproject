using System.Collections.Generic;
using UnityEngine;

public class JournalState : MonoBehaviour
{
    private readonly HashSet<string> entries = new HashSet<string>();

    public IReadOnlyCollection<string> Entries => entries;

    public bool HasEntry(string entryId)
    {
        return entries.Contains(entryId);
    }

    public void AddEntry(string entryId)
    {
        if (!string.IsNullOrWhiteSpace(entryId))
        {
            entries.Add(entryId);
        }
    }
}
