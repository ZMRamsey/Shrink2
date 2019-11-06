using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    Rigidbody item;
    Vector3 movingDirection;

    bool objectOnBelt;

    public float pushForce;

    // Start is called before the first frame update
    void Start()
    {
        movingDirection = transform.forward;
    }

    private void OnCollisionStay(Collision collision)
    {
        item = collision.gameObject.GetComponent<Rigidbody>();
        //item.AddForce(movingDirection * pushForce);
        item.velocity = pushForce * movingDirection * Time.deltaTime;
        //item.transform.Translate(movingDirection * pushForce * Time.deltaTime);
    }

    public void Invert()
    {
        movingDirection *= -1;
    }
}
