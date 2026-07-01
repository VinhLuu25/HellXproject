using System;
using UnityEngine;

public class LocalSaveStore : MonoBehaviour
{
    private const string SaveKey = "hellx.localSave";
    private const string BackendSnapshotKey = "hellx.backendSnapshot";

    public void SaveCheckpoint(string roomId, Vector2 playerPosition)
    {
        SavePayload payload = SavePayloadBuilder.BuildFallback("interaction", playerPosition);
        payload.currentRoom = roomId;
        SaveCheckpoint(payload);
    }

    public void SaveCheckpoint(SavePayload payload)
    {
        if (payload == null)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(payload.savedAt))
        {
            payload.savedAt = DateTime.UtcNow.ToString("O");
        }

        PlayerPrefs.SetString(SaveKey, JsonUtility.ToJson(payload));
        PlayerPrefs.Save();
    }

    public bool TryLoad(out SavePayload data)
    {
        if (!PlayerPrefs.HasKey(SaveKey))
        {
            data = null;
            return false;
        }

        data = JsonUtility.FromJson<SavePayload>(PlayerPrefs.GetString(SaveKey));
        return data != null;
    }

    public void SaveBackendSnapshot(string rawJson)
    {
        PlayerPrefs.SetString(BackendSnapshotKey, rawJson);
        PlayerPrefs.Save();
    }

    public bool TryLoadBackendSnapshot(out string rawJson)
    {
        rawJson = PlayerPrefs.GetString(BackendSnapshotKey, string.Empty);
        return !string.IsNullOrEmpty(rawJson);
    }
}
