using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string firstRoomSceneName = "Chapter01_Room01";

    public void StartGame()
    {
        SceneManager.LoadScene(firstRoomSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
