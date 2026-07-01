using System.Collections.Generic;
using UnityEngine;

public class PuzzleState : MonoBehaviour
{
    private readonly HashSet<string> solvedPuzzles = new HashSet<string>();

    public IReadOnlyCollection<string> SolvedPuzzles => solvedPuzzles;

    public bool IsSolved(string puzzleId)
    {
        return solvedPuzzles.Contains(puzzleId);
    }

    public void MarkSolved(string puzzleId)
    {
        if (!string.IsNullOrWhiteSpace(puzzleId))
        {
            solvedPuzzles.Add(puzzleId);
        }
    }
}
