using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour {
    private Transform[] Hearts = new Transform[6];

    private Character Character;


    private void Awake()
    {
        Character = FindObjectOfType<Character>();

        for (int i = 0; i < Hearts.Length; i++)
        {
            Hearts[i] = transform.GetChild(i);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < Character.Lives1)
                Hearts[i].gameObject.SetActive(true);
            else Hearts[i].gameObject.SetActive(false);
        }
    }
}
