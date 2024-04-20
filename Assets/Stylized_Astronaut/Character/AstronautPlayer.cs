using UnityEngine;
using System.Collections;


namespace AstronautPlayer
{

    public class AstronautPlayer : MonoBehaviour
    {

        private Animator anim;
         private CharacterController controller;

         public float speed = 600.0f;
         public float turnSpeed = 400.0f;
        private Vector3 moveDirection;
        public float gravity = 20.0f;
        public float moveSpeed=15;

        void Start()
        {
           controller = GetComponent<CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();
        }

        void Update()
        {
            if (Input.GetKey("w"))
            {
                anim.SetInteger("AnimationPar", 1);
                //moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            }
            else
            {
                anim.SetInteger("AnimationPar", 0);
                //moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            }
            moveDirection =new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;

            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
            moveSpeed = Input.GetAxisRaw("Vertical") * speed;
            moveDirection = transform.forward * moveSpeed;
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
        private void FixedUpdate()
        {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection*moveSpeed*Time.deltaTime));
        }
    }
}

//    public class AstronautPlayer : MonoBehaviour

//{
//    private Animator anim;
//    private CharacterController controller;

//    public float speed = 6.0f;
//    public float turnSpeed = 400.0f;
//    public float gravity = 20.0f;

//        void Start()
//    {
//        controller = GetComponent<CharacterController>();
//        anim = GetComponentInChildren<Animator>();
//    }

//    void Update()
//    {
//        float horizontalInput = Input.GetAxis("Horizontal");
//        float verticalInput = Input.GetAxis("Vertical");

//        HandleMovement(horizontalInput, verticalInput);
//        HandleRotation(horizontalInput);

//        // Check if the character is grounded for any other actions or animations
//        bool grounded = IsGrounded();
//        anim.SetBool("Grounded", grounded);

//        // Add other actions/animations based on player input or state
//    }

//    void HandleMovement(float horizontal, float vertical)
//    {
//        // Calculate the movement direction
//        Vector3 moveDirection = (transform.forward * vertical + transform.right * horizontal).normalized;

//        // Apply gravity
//        if (!controller.isGrounded)
//        {
//            moveDirection.y -= gravity * Time.deltaTime;
//        }

//        // Move the controller
//        controller.Move(moveDirection * speed * Time.deltaTime);

//        // Set the animation parameter based on movement input
//        float moveMagnitude = new Vector2(horizontal, vertical).magnitude;
//        anim.SetFloat("MoveSpeed", moveMagnitude);
//    }

//    void HandleRotation(float horizontal)
//    {
//        // Rotate the player based on horizontal input
//        transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);
//    }

//    bool IsGrounded()
//    {
//        // A small downward raycast to check if the character is close to the ground.
//        return Physics.Raycast(transform.position, Vector3.down, controller.height / 2 + 0.2f);
//    }
//}
//}

