using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool growing = false;
    public bool shrunk = true;
    public float growth;
    private Vector3 moveDirection;
    private Vector3 lookDirection;
    private float rotX;
    private float rotY;
    private Rigidbody body;

    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Camera")]
    public float xSensitivity;
    public float ySensitivity;
    public float clamp;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        rotX = lookDirection.x;
        rotY = lookDirection.y;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Jump()
    {
        body.AddForce(Vector3.up * jumpForce);
    }

    void Shrink()
    {
        if (!shrunk)
        {
            growth = -0.05f;
            shrunk = true;
            growing = true;
        }
        else
        {

            growth = 0.05f;
            shrunk = false;
            growing = true;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        //Take inputs
        float horiMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        float mouseX = (Input.GetAxis("Mouse Y") * -1);
        float mouseY = Input.GetAxis("Mouse X");
     
        //And check for jump
        if (Input.GetAxis("Jump") > 0) { Jump(); }

        if (Input.GetKeyDown("e")){ Shrink(); }

        //Move camera
        rotX += mouseX * xSensitivity * Time.deltaTime *10;
        rotY += mouseY * ySensitivity * Time.deltaTime*10;

        //Clamp x rotation to prevent flipping
        rotX = Mathf.Clamp(rotX, -clamp, clamp);

        lookDirection.Set(rotX, rotY, 0.0f);

        body.rotation = Quaternion.Euler(lookDirection);



        //Move character
        moveDirection = (horiMovement * transform.right + vertMovement * transform.forward).normalized;
        moveDirection *= moveSpeed * Time.deltaTime;
        body.velocity = moveDirection;


        while (growing)
        {
            body.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * growth;
           if ((body.transform.localScale.z <= 0.2f) || (body.transform.localScale.z >= 1.0f))
            {
                growing = false;
            }
        }
    }
}
