using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactionMessage = "You found a clue.";

    public string Interact()
    {
        return interactionMessage;
    }
}
