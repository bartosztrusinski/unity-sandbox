using UnityEngine;

public class GravityMovement : MonoBehaviour
{
    readonly string JUMPING_STATE = "isJumping";
    readonly string FALLING_STATE = "isFalling";
    readonly string GROUNDED_STATE = "isGrounded";

    public CharacterController controller;
    public Transform groundCheck;
    public Animator playerAnimator;

    public LayerMask groundMask;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 1f;

    Vector3 velocity;
    bool isGrounded;
    bool isJumping;

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
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void UpdateIsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (playerAnimator)
        {
            playerAnimator.SetBool(GROUNDED_STATE, isGrounded);
        }
    }

    void HandleGrounded()
    {
        velocity.y = -2f;
        isJumping = false;

        if (playerAnimator)
        {
            playerAnimator.SetBool(JUMPING_STATE, false);
            playerAnimator.SetBool(FALLING_STATE, false);
        }
    }

    bool ShouldJump()
    {
        return isGrounded && Input.GetButtonDown("Jump");
    }

    void HandleJump()
    {
        if (playerAnimator)
        {
            playerAnimator.SetBool(JUMPING_STATE, true);
        }

        isJumping = true;
        velocity.y = Mathf.Sqrt(jumpHeight * gravity * -2f);
    }

    bool IsFalling()
    {
        return (isJumping && velocity.y < 0f) || velocity.y < -4f;
    }
    void HandleFalling()
    {
        if (playerAnimator)
        {
            playerAnimator.SetBool(FALLING_STATE, true);
        }
    }
}
