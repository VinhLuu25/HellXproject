using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class BackendClient : MonoBehaviour
{
    [SerializeField] private string baseUrl = "http://localhost:3000";
    [SerializeField] private int timeoutSeconds = 5;

    public IEnumerator GetHealth(Action<BackendResult<BackendHealthResponse>> onComplete)
    {
        yield return SendGet("/health", onComplete);
    }

    public IEnumerator StartTestSession(Action<BackendResult<BackendSessionResponse>> onComplete)
    {
        yield return SendPost("/session/test", string.Empty, onComplete);
    }

    public IEnumerator LoadCurrentSave(Action<BackendResult<BackendSaveResponse>> onComplete)
    {
        yield return SendGet("/save/current", onComplete);
    }

    private IEnumerator SendGet<T>(string path, Action<BackendResult<T>> onComplete)
    {
        using UnityWebRequest request = UnityWebRequest.Get(BuildUrl(path));
        request.timeout = timeoutSeconds;

        yield return request.SendWebRequest();

        CompleteRequest(request, onComplete);
    }

    private IEnumerator SendPost<T>(string path, string body, Action<BackendResult<T>> onComplete)
    {
        using UnityWebRequest request = new UnityWebRequest(BuildUrl(path), "POST");
        byte[] payload = System.Text.Encoding.UTF8.GetBytes(body);
        request.uploadHandler = new UploadHandlerRaw(payload);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.timeout = timeoutSeconds;

        yield return request.SendWebRequest();

        CompleteRequest(request, onComplete);
    }

    private string BuildUrl(string path)
    {
        return $"{baseUrl.TrimEnd('/')}{path}";
    }

    private void CompleteRequest<T>(UnityWebRequest request, Action<BackendResult<T>> onComplete)
    {
        if (request.result != UnityWebRequest.Result.Success)
        {
            onComplete?.Invoke(BackendResult<T>.Failure(request.error));
            return;
        }

        if (request.responseCode < 200 || request.responseCode >= 300)
        {
            onComplete?.Invoke(BackendResult<T>.Failure($"HTTP {request.responseCode}"));
            return;
        }

        string rawJson = request.downloadHandler.text;
        T value = JsonUtility.FromJson<T>(rawJson);
        onComplete?.Invoke(BackendResult<T>.Success(value, rawJson));
    }
}
