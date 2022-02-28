using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadScene("TheRiver");
    } 

    public void LoadSettings()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
 
}
