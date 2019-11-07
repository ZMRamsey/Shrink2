using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to activate or diactivate a Door, or in any general change the position of a game object in the scene.

public class DoorActivator : MonoBehaviour
{
    public GameObject activateObject;
    public Vector3 direction;

    public float transitionSpeed;

    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 pointC;
    private bool isColliding;
    private bool shouldMove;

    private float t = 0;

    void Start()
    {
        pointA = activateObject.transform.position;
        pointB = pointA + direction;
        pointC = pointB - direction;
    }

    void Update()
    {
        if (shouldMove == true && isColliding == true)
        {
            t += Time.deltaTime;

            activateObject.transform.position = Vector3.Lerp(pointA, pointB, t / transitionSpeed);
        }

        if (shouldMove == true && isColliding == false)
        {
            t += Time.deltaTime;

            activateObject.transform.position = Vector3.Lerp(activateObject.transform.position, pointC, t / transitionSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
        t = 0;
        Debug.Log(isColliding);
    }

    private void OnCollisionStay(Collision collision)
    {
        shouldMove = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        t = 0;
        isColliding = false;
        Debug.Log(isColliding);
    }
}
