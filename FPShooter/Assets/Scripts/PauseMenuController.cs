using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {


    public bool isPaused;
    public GameObject pauseCanvas;
    public string titleScene;

    void Start()
    {

    }

    void Update()
    {
        if (isPaused)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }
    
    public void Unpause()
    {
        isPaused = false;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadSceneAsync(titleScene);
    }
    
}