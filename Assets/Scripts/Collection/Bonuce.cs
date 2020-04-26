using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonuce : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character Character = collider.GetComponent<Character>();

        if (Character)
        {
            Character.Bonuce++;
            Destroy(gameObject);
        }
    }
}
