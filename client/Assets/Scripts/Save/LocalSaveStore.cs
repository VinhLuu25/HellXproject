using System;
using UnityEngine;

public class LocalSaveStore : MonoBehaviour
{
    private const string SaveKey = "hellx.localSave";
    private const string BackendSnapshotKey = "hellx.backendSnapshot";

    public void SaveCheckpoint(string roomId, Vector2 playerPosition)
    {
        LocalSaveData data = new LocalSaveData
        {
            roomId = roomId,
            playerX = playerPosition.x,
            playerY = playerPosition.y,
            savedAt = DateTime.UtcNow.ToString("O")
        };

        PlayerPrefs.SetString(SaveKey, JsonUtility.ToJson(data));
        PlayerPrefs.Save();
    }

    public bool TryLoad(out LocalSaveData data)
    {
        if (!PlayerPrefs.HasKey(SaveKey))
        {
            data = null;
            return false;
        }

        data = JsonUtility.FromJson<LocalSaveData>(PlayerPrefs.GetString(SaveKey));
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

[Serializable]
public class LocalSaveData
{
    public string roomId;
    public float playerX;
    public float playerY;
    public string savedAt;
}
