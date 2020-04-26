using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
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
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
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
