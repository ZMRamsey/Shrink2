﻿using System.Collections;
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
        
    }

    void PickUp()
    {
        Debug.DrawRay(transform.position, guide.transform.forward, Color.magenta);
        if (Physics.Raycast(transform.position, guide.transform.forward, out RaycastHit hit, reach))
        {
            item = hit.collider.gameObject; 
            if (item.tag == "Box")
            {
                //Pick up box
                holding = true;
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
        //lookDirection = movement.GetLookDirection();
        lookDirection = guide.transform.rotation.eulerAngles;

        if (Input.GetAxis("Interact") > 0)
        {
            if (!holding)
            {
                PickUp();
            }
            else
            {
                holding = false;
            }
        }
        if (holding)
        {
            item.transform.position = guide.transform.position;
            item.transform.rotation = Quaternion.Euler(guide.transform.up);
        }
    }
}