using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Rigidbody body;
    public float cOfMScale;
    Renderer box;

    void Start()
    {
        box = GetComponent<Renderer>();
        Vector3 boxSize = box.bounds.size;
        body = GetComponent<Rigidbody>();
        body.centerOfMass = body.centerOfMass + (Vector3.down * (boxSize.y * cOfMScale));
        body.sleepThreshold = 0.0f;
    }
}