using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 moveDirection;
    private Vector3 lookDirection;
    private float rotX;
    private float rotY;
    private Rigidbody body;
    private CapsuleCollider capsule;

    [Header("Movement")]
    public float moveSpeed; //150
    public float jumpForce; //120

    [Header("Camera")]
    public float xSensitivity; //100
    public float ySensitivity; //100
    public float clamp;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        rotX = lookDirection.x;
        rotY = lookDirection.y;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public Vector3 GetLookDirection()
    {
        return gameObject.transform.rotation.eulerAngles;
    }
    bool GroundCheck()
    {
        float distToGround = capsule.bounds.extents.y;
        
        return Physics.Raycast(transform.position, -Vector3.up, distToGround = 0.5f);
    }

    void Jump()
    {
        body.AddForce(Vector3.up * jumpForce);
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
        if ((Input.GetAxis("Jump") > 0) && GroundCheck()) { Jump(); }

        //Move camera
        rotX += mouseX * xSensitivity * Time.deltaTime;
        rotY += mouseY * ySensitivity * Time.deltaTime;

        //Clamp x rotation to prevent flipping
        rotX = Mathf.Clamp(rotX, -clamp, clamp);

        lookDirection.Set(rotX, rotY, 0.0f);

        body.rotation = Quaternion.Euler(lookDirection);

        //Move character
        moveDirection = (horiMovement * transform.right + vertMovement * transform.forward).normalized;
        moveDirection *= moveSpeed * Time.deltaTime;
        if (!GroundCheck()) { moveDirection.y = 0; }
        body.velocity = moveDirection;
    }
}
