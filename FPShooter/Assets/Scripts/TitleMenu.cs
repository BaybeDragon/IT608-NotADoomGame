using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{

    public string firstLevel;

    public void NewGame()
    {
        SceneManager.LoadSceneAsync(firstLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
