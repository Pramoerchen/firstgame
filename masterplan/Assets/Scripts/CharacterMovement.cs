using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //
    public CharacterController _characterController;
    public float speed;
    public float gravity;
    public float jumpheight = 3f;
    
    public Transform GroundCheck;
    public float checkDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 gravitymovement;

    bool isGrounded;

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(GroundCheck.position, checkDistance, groundMask);

        if (isGrounded && gravitymovement.y < 0)
        {
            gravitymovement.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            gravitymovement.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        gravitymovement.y += gravity * Time.deltaTime;

        _characterController.Move(gravitymovement * Time.deltaTime);
    }
}
