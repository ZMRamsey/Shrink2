using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : MonoBehaviour
{
    bool holding = false;
    public float reach;
    GameObject item;
    public Component camera;
    public GameObject guide;
    public PlayerMove movement;
    [SerializeField] KeyCode HoldKey;


    private void Start()
    {
        
    }

    void PickUp()
    {
        if (!movement.shrunk)
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
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(HoldKey))
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
