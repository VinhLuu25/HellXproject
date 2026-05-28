using TMPro;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;

    private bool canInteract;

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            statusText.text = "Interaction detected. Backend sync placeholder.";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            canInteract = true;
            statusText.text = "Press E to sync progress";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            canInteract = false;
            statusText.text = "Find the sync object and press E";
        }
    }
}