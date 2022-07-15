using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void quit()
    {
        Application.Quit();
    }
    
    public void loadPrologue()
    {
        SceneManager.LoadScene("Prologue");

    }
}
