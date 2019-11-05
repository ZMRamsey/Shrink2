using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    Rigidbody item;
    Vector3 movingDirection;

    bool objectOnBelt;

    public float pushForce;

    public bool active;

    void Start()
    {
        movingDirection = transform.up;
    }

    private void OnCollisionStay(Collision collision)
    {
        item = collision.gameObject.GetComponent<Rigidbody>();
        if (active)
        {
           
            //item.AddForce(movingDirection * pushForce);
            item.velocity = pushForce * movingDirection * Time.deltaTime;
            //item.transform.Translate(movingDirection * pushForce * Time.deltaTime);
        }
    }

    public void SetActivate(bool state)
    {
        active = state;
    }


    public void Invert()
    {
        movingDirection *= -1;
    }
}
