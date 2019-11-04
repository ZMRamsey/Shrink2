using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : MonoBehaviour
{
    bool holding = false;
    Vector3 lookDirection;
    public float reach;
    public PlayerMove movement;
    GameObject item;
    public GameObject guide;

    private void Start()
    {
        
        //guide = gameObject.GetComponentInChildren(
    }

    void pickUp()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, lookDirection, Color.magenta);
        if (Physics.Raycast(transform.position, lookDirection, out hit, reach))
        {
            item = hit.collider.gameObject;
            if (item.tag == "Box")
            {
                //Pick up box
                holding = true;
                while (holding)
                {
                    item.gameObject.transform.position = guide.transform.position;
                }
            }
            else if (item.tag == "Button")
            {
                //Press the button
            }
            //else nothing
        }
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = movement.GetLookDirection();

        if (Input.GetAxis("Interact") > 0)
        {
            if (!holding)
            {
                Debug.Log("e pressed");
                //pickup
                pickUp();
            }
            else
            {
                //drop
                holding = false;
            }
        }
    }
}
