
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void Loadgame()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        //SceneManager.LoadScene("Level01");
        SceneManager.LoadScene("Level01Doors");
    }

    public void loadStartingScreen()
    {
        SceneManager.LoadScene("StartingScreen");
    }

    public void loadGameOver()
    {
        SceneManager.LoadScene("GameOverDoors");
    }
}

