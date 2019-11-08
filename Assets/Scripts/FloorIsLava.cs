using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsLava : MonoBehaviour
{
    public GameObject floor; //is lava
    public int damage;

    HealthScript health;
    Collider coll;
    float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        coll = gameObject.GetComponent<Collider>();
        health = gameObject.GetComponent<HealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        distToGround = coll.bounds.extents.y;
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit);
        if ((hit.distance <= distToGround + 0.1f) && (hit.collider.gameObject.tag == "Lava"))
        {
            //health.currentHealth -= damage;
            health.Damage(damage);
            //if (health.currentHealth < 0) { health.respawnArea(); }
        }
    }
}
