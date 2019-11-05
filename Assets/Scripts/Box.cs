using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Rigidbody body;
    public float cOfMScale;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.centerOfMass = body.centerOfMass + (Vector3.down * cOfMScale);
    }
}