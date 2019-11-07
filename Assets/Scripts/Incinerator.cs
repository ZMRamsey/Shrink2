using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The incinerator script. Attach the script in a GameObject in the bottom of the incinerator.

public class Incinerator : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Store the information of the game object colliding with the "collision" object.
        GameObject collidingObject = collision.collider.gameObject;

        HealthScript health = collidingObject.GetComponent<HealthScript>();

        //Debug.Log(collidingObject);
        if (collidingObject.tag == "Box") // Look for the tag of the game object stored above.
        {
            health.Damage(100);
        }
    }
}
