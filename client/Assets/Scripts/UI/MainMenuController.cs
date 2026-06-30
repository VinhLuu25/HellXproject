using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string firstRoomSceneName = "FirstRoom";

    public void StartGame()
    {
        SceneManager.LoadScene(firstRoomSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
