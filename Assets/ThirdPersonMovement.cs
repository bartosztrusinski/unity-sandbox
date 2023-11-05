using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    readonly string MOVING_STATE = "isMoving";
    readonly string SPRINTING_STATE = "isSprinting";
    readonly string JUMPING_STATE = "isJumping";
    readonly string FALLING_STATE = "isFalling";
    readonly string GROUNDED_STATE = "isGrounded";

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

    bool ShouldMove(Vector3 direction)
    {
        return direction.magnitude >= 0.1f;
    }

    void UpdateIsSprinting()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        playerAnimator.SetBool(SPRINTING_STATE, isSprinting);
    }

    void HandleMove(Vector3 direction)
    {
        UpdateIsSprinting();
        playerAnimator.SetBool(MOVING_STATE, true);

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        controller.Move(speed * (isSprinting ? 2 : 1) * Time.deltaTime * moveDirection.normalized);
    }

    void HandleIdle()
    {
        playerAnimator.SetBool(MOVING_STATE, false);
        playerAnimator.SetBool(SPRINTING_STATE, false);
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleGrounded()
    {
        velocity.y = -2f;
        isJumping = false;
        playerAnimator.SetBool(JUMPING_STATE, false);
        playerAnimator.SetBool(FALLING_STATE, false);
    }

    bool ShouldJump()
    {
        return isGrounded && Input.GetButtonDown("Jump");
    }

    void HandleJump()
    {
        playerAnimator.SetBool(JUMPING_STATE, true);
        isJumping = true;
        velocity.y = Mathf.Sqrt(jumpHeight * gravity * -2f);
    }

    void HandleFalling()
    {
        playerAnimator.SetBool(FALLING_STATE, true);
    }

    bool IsFalling()
    {
        return (isJumping && velocity.y < 0f) || velocity.y < -4f;
    }

    void UpdateIsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        playerAnimator.SetBool(GROUNDED_STATE, isGrounded);
    }

    Vector3 ComputeDirection()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");
        return new Vector3(horizontalAxis, 0f, verticalAxis).normalized;
    }

    void Update()
    {
        ApplyGravity();
        UpdateIsGrounded();

        if (isGrounded && velocity.y < 0f)
        {
            HandleGrounded();
        }

        if (ShouldJump())
        {
            HandleJump();
        }

        if (IsFalling())
        {
            HandleFalling();
        }

        Vector3 direction = ComputeDirection();

        if (ShouldMove(direction))
        {
            HandleMove(direction);
        }
        else
        {
            HandleIdle();
        }
    }
}
