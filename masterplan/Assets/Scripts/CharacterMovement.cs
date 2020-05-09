using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Variablen
    public float speed;
    public float gravity;
    public float jumpForce;
    [SerializeField] private float currentGravity = 0;
    private CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 FinalMovement = (Movement() * speed) + Gravitation();
        _characterController.Move(FinalMovement);

        //Gravitation
        Vector3 Gravitation()
        {
            Vector3 gravitymovement = new Vector3(0, -currentGravity, 0);
            currentGravity += gravity * Time.deltaTime;
            if (_characterController.isGrounded)
            {
                currentGravity = 0.01f;
            }
            if (Input.GetButtonDown("Jump") && _characterController.isGrounded)
            {
                currentGravity -= jumpForce * Time.deltaTime;
            }
            return gravitymovement;
        }

        //Movement
        Vector3 Movement()
        {
            Vector3 MoveVector = Vector3.zero;

            MoveVector += transform.forward * Input.GetAxis("Vertical");
            MoveVector += transform.right * Input.GetAxis("Horizontal");
            MoveVector *= Time.deltaTime;
            return MoveVector;
        }

    }
}
