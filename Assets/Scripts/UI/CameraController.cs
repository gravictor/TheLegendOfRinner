using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private float Speed = 2.0F;
    [SerializeField]
    private Transform Target;

    private void Awake()
    {
        if (!Target) Target = FindObjectOfType<Character>().transform;
    }

    private void Update()
    {
        Vector3 position = Target.position; position.z = -10.0f;
        transform.position = Vector3.Lerp(transform.position, position, Speed * Time.deltaTime);
    }
}
