using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(1);
    }
}
