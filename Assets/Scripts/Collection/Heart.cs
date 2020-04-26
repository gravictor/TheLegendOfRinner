using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character Character = collider.GetComponent<Character>();

        if (Character)
        {
            Character.Lives1++;
            Destroy(gameObject);
        }
    }
}
