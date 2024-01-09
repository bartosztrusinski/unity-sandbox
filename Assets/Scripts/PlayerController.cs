
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [SerializeField] private float playerSpeed = 18.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = .8f;

    private InputAction moveAction;
    private InputAction jumpAction;
    [SerializeField] private Camera cam;
    private Transform cameraTransform;

    private Animator animator;
    int moveZParameterId;
    int moveXParameterId;
    int jumpAnimation;

    Vector2 currentAnimationBlendVector;
    Vector2 animationVelocity;
    [SerializeField] private float animationSmoothTime = 0.1f;
    [SerializeField] private float animationPlayTransition = 0.15f;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        cameraTransform = cam.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];


        animator = GetComponent<Animator>();
        moveXParameterId = Animator.StringToHash("MoveX");
        moveZParameterId = Animator.StringToHash("MoveZ");
        jumpAnimation = Animator.StringToHash("Pistol Jump");
    }


    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        currentAnimationBlendVector = Vector2.SmoothDamp(currentAnimationBlendVector, input, ref animationVelocity, animationSmoothTime);
        Vector3 move = new Vector3(currentAnimationBlendVector.x, 0, currentAnimationBlendVector.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;    
        controller.Move(move * Time.deltaTime * playerSpeed);

        animator.SetFloat(moveXParameterId, currentAnimationBlendVector.x);
        animator.SetFloat(moveZParameterId, currentAnimationBlendVector.y);

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.CrossFade(jumpAnimation, animationPlayTransition);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        Quaternion targetRotation = Quaternion.Euler(0,cameraTransform.eulerAngles.y,0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
}