using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPanelButton : MonoBehaviour {
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
