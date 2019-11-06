using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    private CharacterController charController;
    private Rigidbody body;
   

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode JumpKey;
    private bool isJumping;

    [SerializeField] private KeyCode ShrinkKey;
    private bool isShrinking;
    private bool shrunk;

    private float heightVal;
    private float heightRad;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        body = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        PlayerMovement();
        JumpInput();
        ShrinkInput();
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(JumpKey) && !isJumping)
        {
            
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }


    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir = Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;

    }

    private IEnumerator ShrinkEvent()
    {
       if(shrunk)
        {
            heightVal = 0.5f;
            heightRad = 0.125f;
        }
        else
        {
            heightVal = -0.5f;
            heightRad = -0.125f;
        }
        
        do
        {
            yield return new WaitForSeconds(0.01f);
            charController.height += heightVal;
            charController.radius += heightRad;
            if (charController.height == 0.5f || charController.height == 2.0f){
                isShrinking = false;
            }
        } while (isShrinking);
    }
    private void ShrinkInput()
    {
        if (Input.GetKeyDown(ShrinkKey) && !isShrinking && !shrunk)
        {
            isShrinking = true;
            StartCoroutine(ShrinkEvent());    
            shrunk = true;
        }
        else if (Input.GetKeyDown(ShrinkKey) && !isShrinking && shrunk)
        {
            isShrinking = true;
            StartCoroutine(ShrinkEvent());
            shrunk = false;
        }
      

    }
   
}
