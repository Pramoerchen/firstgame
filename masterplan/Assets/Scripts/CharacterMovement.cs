using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Variablen
    public float speed;
    public float gravity;
    public float jumpForce;
    private CharacterController _characterController;
    private Vector3 MoveVector = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_characterController.isGrounded)
        {

            MoveVector = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            MoveVector *= speed;

            if (Input.GetButton("Jump"))
            {
                MoveVector.y = jumpForce;
            }
        }
        MoveVector.y -= gravity * Time.deltaTime;
        _characterController.Move(MoveVector * Time.deltaTime);

    }
}
