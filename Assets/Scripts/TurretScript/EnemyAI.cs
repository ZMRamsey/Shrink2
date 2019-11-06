using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just used for testing the turret AI. Make a target object move from point A to point B.
public class EnemyAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.Sin(Time.time * speed));
    }
}
