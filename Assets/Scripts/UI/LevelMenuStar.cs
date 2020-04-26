using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuStar : MonoBehaviour {
    public GameObject S1L1, S2L1, S3L1;
    void Start()
    {
        StarLevel1();
    }
    void StarLevel1()
    {
        if (PlayerPrefs.GetInt("MaxScore") < 6){}
        if (PlayerPrefs.GetInt("MaxScore") > 6 && PlayerPrefs.GetInt("MaxScore") < 12)
            S1L1.SetActive(true);
        if (PlayerPrefs.GetInt("MaxScore") > 12 && PlayerPrefs.GetInt("MaxScore") < 20)
        {
            S1L1.SetActive(true);
            S2L1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("MaxScore") > 20)
        {
            S1L1.SetActive(true);
            S2L1.SetActive(true);
            S3L1.SetActive(true);
        }
    }
}
