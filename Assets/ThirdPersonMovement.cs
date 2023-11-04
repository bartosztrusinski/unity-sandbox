using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;
    public Animator playerAnimator;

    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 1f;

    float turnSmoothVelocity;
    Vector3 velocity;
    bool isGrounded;
    bool isSprinting;
    bool isJumping;

    string MOVING_STATE = "isMoving";
    string SPRINTING_STATE = "isSprinting";
    string JUMPING_STATE = "isJumping";
    string FALLING_STATE = "isFalling";
    string GROUNDED_STATE = "isGrounded";

    void Update()
    {
        // GRAVITY
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        playerAnimator.SetBool(GROUNDED_STATE, isGrounded);

        if (isGrounded)
        {
            isJumping = false;
            playerAnimator.SetBool(JUMPING_STATE, false);
            playerAnimator.SetBool(FALLING_STATE, false);
        }

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        // WHEN ON GROUND AND JUMP PRESSED
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerAnimator.SetBool(JUMPING_STATE, true);
            isJumping = true;
            velocity.y = Mathf.Sqrt(jumpHeight * gravity * -2f);
        }

        // WHEN FALLING DOWN
        if (isJumping && velocity.y < 0f || velocity.y < -2f)
        {
            playerAnimator.SetBool(FALLING_STATE, true);
        }


        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalAxis, 0f, verticalAxis).normalized;

        // WHEN MOVING
        if (direction.magnitude >= 0.1f)
        {
            playerAnimator.SetBool(MOVING_STATE, true);

            isSprinting = Input.GetKey(KeyCode.LeftShift);
            playerAnimator.SetBool(SPRINTING_STATE, isSprinting);

            // ROTATE PLAYER
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

            // MOVE PLAYER
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(speed * (isSprinting ? 2 : 1) * Time.deltaTime * moveDirection.normalized);
        }
        // WHEN NOT MOVING
        else
        {
            playerAnimator.SetBool(MOVING_STATE, false);
            playerAnimator.SetBool(SPRINTING_STATE, false);
        }

    }
}
