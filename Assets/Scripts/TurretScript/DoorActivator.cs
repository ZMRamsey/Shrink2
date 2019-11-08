using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to activate or diactivate a Door, or in any general change the position of a game object in the scene.

public class DoorActivator : MonoBehaviour
{
    public GameObject activateObject; // The object that we want to trigger.
    public Vector3 direction; // The the direction where we want to move our object.

    public float transitionSpeed; // The speed of the movement.

    private Vector3 pointA; // The inizial point.
    private Vector3 pointB; // The point of destination.
    private Vector3 pointC; // The point needed for the inverse movement.
    private bool isColliding;
    private bool shouldMove;

    private float t = 0;

    void Start()
    {   // Set the starting Point, the point of the first activation and the point for the inverse activation.
        pointA = activateObject.transform.position;
        pointB = pointA + direction;
        pointC = pointB - direction;
    }

    void Update()
    {   
        // First activation if the object is colliding.
        if (isColliding == true)
        {
            t += Time.deltaTime; // Needed for a smooth movement.
            
            activateObject.transform.position = Vector3.Lerp(pointA, pointB, t / transitionSpeed);
        }
        // The inverse action is triggered when nothing is colliding.
        if (isColliding == false)
        {
            t += Time.deltaTime;

            activateObject.transform.position = Vector3.Lerp(activateObject.transform.position, pointC, t / transitionSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        t = 0;
        isColliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        t = 0;
        isColliding = false;
    }
}
