using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    readonly string MOVING_STATE = "isMoving";
    readonly string SPRINTING_STATE = "isSprinting";

    public CharacterController controller;
    public Transform cam;
    public Animator playerAnimator;

    public float speed = 5f;
    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;
    bool isSprinting;

    void Update()
    {
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
    Vector3 ComputeDirection()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");
        return new Vector3(horizontalAxis, 0f, verticalAxis).normalized;
    }

    bool ShouldMove(Vector3 direction)
    {
        return direction.magnitude >= 0.1f;
    }

    void HandleMove(Vector3 direction)
    {
        UpdateIsSprinting();

        if (playerAnimator)
        {
            playerAnimator.SetBool(MOVING_STATE, true);
        }

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        controller.Move(speed * (isSprinting ? 2 : 1) * Time.deltaTime * moveDirection.normalized);
    }

    void UpdateIsSprinting()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        if (playerAnimator)
        {
            playerAnimator.SetBool(SPRINTING_STATE, isSprinting);
        }
    }

    void HandleIdle()
    {
        if (playerAnimator)
        {
            playerAnimator.SetBool(MOVING_STATE, false);
            playerAnimator.SetBool(SPRINTING_STATE, false);
        }
    }
}
