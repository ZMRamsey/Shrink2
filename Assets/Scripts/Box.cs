using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Vector3 objectPos;
    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

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

    void Update()
    {
        if (isHolding == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    public void Holding()
    { 
        isHolding = true;
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;
    }

    public void Dropped()
    {
        isHolding = false;
    }
}