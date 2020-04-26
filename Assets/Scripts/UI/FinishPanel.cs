using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// до 6 очков - 0 звезд
/// от 6 до 12 очков - 1 звезда
/// от 12 до 20 - 2 звезды
/// от 20 - 3 звезды

public class FinishPanel : MonoBehaviour {
    public GameObject LivesBar, ScoreBar, Pause;
    public GameObject Star1, Star2, Star3;
    private void Start()
    {
        Time.timeScale = 0;
        LivesBar.SetActive(false);
        Pause.SetActive(false);
        ScoreBar.SetActive(false);
        OutputStar();
    }
    void OutputStar()
    {
        if (PlayerPrefs.GetInt("Score") < 6) { }
        if (PlayerPrefs.GetInt("Score") > 6 && PlayerPrefs.GetInt("Score") < 12)
            Star1.SetActive(true);
        if (PlayerPrefs.GetInt("Score") > 12 && PlayerPrefs.GetInt("Score") < 20)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Score") > 20)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
        }
    }
}
