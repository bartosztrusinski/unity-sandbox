
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController2 : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [SerializeField] private float playerSpeed = 18.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = 5f;

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

    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;

    public CinemachineVirtualCamera cinemachineVirtualCamera;


    private void Start()
    {
        GameObject obj = GameObject.Find("CM 3rdPerson2");
        cinemachineVirtualCamera = obj.GetComponent<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.Follow = this.transform;
        cinemachineVirtualCamera.LookAt = this.transform;

        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();

        cameraTransform = cam.transform;


        animator = GetComponent<Animator>();
        moveXParameterId = Animator.StringToHash("MoveX");
        moveZParameterId = Animator.StringToHash("MoveZ");
        jumpAnimation = Animator.StringToHash("Pistol Jump");
    }

    public void OnMove(InputAction.CallbackContext context) {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context) {
        jumped = context.action.triggered;
    }



    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        Vector2 input = movementInput;
        currentAnimationBlendVector = Vector2.SmoothDamp(currentAnimationBlendVector, input, ref animationVelocity, animationSmoothTime);
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        move = move.x * transform.right.normalized + move.z * transform.forward.normalized;
        move.y = 0f;    
        controller.Move(move * Time.deltaTime * playerSpeed);

        animator.SetFloat(moveXParameterId, currentAnimationBlendVector.x);
        animator.SetFloat(moveZParameterId, currentAnimationBlendVector.y);

        // Changes the height position of the player..
        if (jumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.CrossFade(jumpAnimation, animationPlayTransition);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        
        Quaternion targetRotation = Quaternion.Euler(0, controller.transform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}
