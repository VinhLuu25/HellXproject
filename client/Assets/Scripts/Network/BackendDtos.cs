using System;

[Serializable]
public class BackendHealthResponse
{
    public string status;
    public string service;
    public string timestamp;
}

[Serializable]
public class BackendSessionResponse
{
    public string sessionId;
    public string playerId;
    public string mode;
}

[Serializable]
public class BackendPositionResponse
{
    public float x;
    public float y;
}

[Serializable]
public class BackendSaveResponse
{
    public string playerId;
    public string sessionId;
    public string currentChapter;
    public string currentRoom;
    public string checkpointId;
    public BackendPositionResponse position;
    public string[] inventoryItems;
    public string[] collectedClues;
    public string[] journalEntries;
    public string[] puzzleFlags;
    public string updatedAt;
}

public class BackendResult<T>
{
    public bool IsSuccess { get; private set; }
    public T Value { get; private set; }
    public string Error { get; private set; }
    public string RawJson { get; private set; }

    public static BackendResult<T> Success(T value, string rawJson)
    {
        return new BackendResult<T>
        {
            IsSuccess = true,
            Value = value,
            Error = string.Empty,
            RawJson = rawJson
        };
    }

    public static BackendResult<T> Failure(string error)
    {
        return new BackendResult<T>
        {
            IsSuccess = false,
            Value = default,
            Error = error,
            RawJson = string.Empty
        };
    }
}
