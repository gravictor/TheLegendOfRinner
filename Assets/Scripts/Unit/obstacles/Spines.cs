using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spines : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Unit Unit = collider.GetComponent<Unit>();

        if (Unit && Unit is Character)
        {
            Unit.ReceiveDamage();
        }
    }
}
