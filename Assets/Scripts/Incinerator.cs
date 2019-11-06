using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incinerator : MonoBehaviour
{
    public int secBeforeActivation = 5;

    //private float timer = 0;

    void OnCollisionEnter(Collision collision)
    {
        // Store the information of the game object colliding with the "collision" object.
        GameObject collidingObject = collision.collider.gameObject;

        Debug.Log(collidingObject);

        if (collidingObject.tag == "Box") // Look for the tag of the game object stored above.
        {
            collidingObject.SetActive(false);
            // Here we should spawn the destroyed object in the spawning area.
        }
    }

    //private IEnumerator waiter()
    //{
    //    yield return new WaitForSeconds(3);
    //}
}
