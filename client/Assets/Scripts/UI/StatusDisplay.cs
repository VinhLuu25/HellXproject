using TMPro;
using UnityEngine;

public class StatusDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private string defaultStatus = "Enter the room.";

    private void Start()
    {
        SetStatus(defaultStatus);
    }

    public void SetStatus(string message)
    {
        if (statusText != null)
        {
            statusText.text = message;
        }
    }
}
