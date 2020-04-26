using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    public GameObject PanelPause, ButtonPause;
    public GameObject v_on, v_off;
    void Start()
    {
        if (gameObject.name == "VolumeOn" || gameObject.name == "VolumeOff")
        {
            if (PlayerPrefs.GetInt("Volume") == 0)
            {
                v_on.SetActive(false);
                v_off.SetActive(true);
            }
            else
            {
                v_on.SetActive(true);
                v_off.SetActive(false);
            }
        }
    }
    public void PauseOn()
    {
        PanelPause.SetActive(true);
        ButtonPause.SetActive(false);
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("Volume") == 0)
        {
            v_on.SetActive(false);
            v_off.SetActive(true);
        }
        else
        {
            v_on.SetActive(true);
            v_off.SetActive(false);
        }
    }
    public void ContinueGame()
    {
        PanelPause.SetActive(false);
        ButtonPause.SetActive(true);
        v_on.SetActive(false);
        v_off.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void VolumeOn()
    {
        PlayerPrefs.SetInt("Volume", 0);
        v_on.SetActive(false);
        v_off.SetActive(true);
    }
    public void VolumeOff()
    {
        PlayerPrefs.SetInt("Volume", 1);
        v_on.SetActive(true);
        v_off.SetActive(false);
    }
}
