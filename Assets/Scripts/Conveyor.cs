using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    Rigidbody item;
    Vector3 movingDirection;
    ActivateComponent activateComponent;

    public float pushForce;

    void Start()
    {
        movingDirection = transform.up;
        activateComponent = GetComponent<ActivateComponent>();
    }

    private void OnCollisionStay(Collision collision)
    {
        item = collision.gameObject.GetComponent<Rigidbody>();
        if (activateComponent.GetState())
        {
            //item.AddForce(movingDirection * pushForce);
            item.velocity = pushForce * movingDirection * Time.deltaTime;
            //item.transform.Translate(movingDirection * pushForce * Time.deltaTime);
        }
    }

    public void Invert()
    {
        movingDirection *= -1;
    }
}
