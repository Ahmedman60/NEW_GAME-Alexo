using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;
    private  bool pause = false;
    private void Start()
    {
        PauseUI.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if (pause)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!pause)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void resume()
    {
        pause = false;
    }
    public void exit()
    {
        Application.Quit();

    }
    public void Restart()
    {
        SceneManager.LoadScene(0);

    }
}
