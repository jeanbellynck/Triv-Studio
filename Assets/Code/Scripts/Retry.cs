
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void Loadgame()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        //SceneManager.LoadScene("Level01");
        Debug.Log("load game");
        SceneManager.LoadScene("Main");
    }

    public void loadStartingScreen()
    {
        SceneManager.LoadScene("StartingScreen");
    }

    public void loadGameOver()
    {
        Debug.Log("load game over");
        SceneManager.LoadScene("GameOver");
    }
}

