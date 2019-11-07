using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used for tracking the Target.

public class TrackingSystem : MonoBehaviour
{

    public float speed = 3.0f;
    public GameObject target = null;
    Vector3 lastKnowPosition = Vector3.zero;
    Quaternion lookAtRotation;


    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            if (lastKnowPosition != target.transform.position)
            {
                lastKnowPosition = target.transform.position;
                lookAtRotation = Quaternion.LookRotation(lastKnowPosition - transform.position);
            }

            if (transform.rotation != lookAtRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, speed * Time.deltaTime);
            }
        }
    }


    bool SetTarget(GameObject target)
    {
        if (target)
        {
            return false;
        }

        this.target = target;

        return true;
    }
}
