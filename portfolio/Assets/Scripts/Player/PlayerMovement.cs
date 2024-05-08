using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    PlayerMovement playerMovement;

    [Header("플레이어 움직임 제어 변수")]
    [SerializeField] private float runSpeed;
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private CharacterController player;

    [Header("카메라 제어 변수")]
    [SerializeField] private ThirdCam thirdCam;
    [SerializeField] private float smoothRotation;
    Quaternion targetRotation;

    [Header("점프 제어 변수")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float gravityValue = 3f;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded = false;

    [Header("애니메이터")]
    private Animator playerAnimator;

    private float activeMoveSpeed;
    private Vector3 movement;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        player = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 playerMoveInput = new Vector3(h, 0, v).normalized;
        float moveAmount = Mathf.Clamp01(Mathf.Abs(h) + Mathf.Abs(v));

        Vector3 moveDirection = thirdCam.transform.forward * playerMoveInput.z + thirdCam.transform.right * playerMoveInput.x;
        moveDirection.y = 0;

        // 달리기
        if (Input.GetKey(KeyCode.LeftShift))
        {
            activeMoveSpeed = runSpeed;
            playerAnimator.SetBool("isRun", true);
        }
        else
        {
            activeMoveSpeed = playerMoveSpeed;
            playerAnimator.SetBool("isRun", false);

        }

        // 점프를 위한 계산식
        float yValue = movement.y;                          // 떨어지고 있는 y의 값을 저장
        movement = moveDirection * activeMoveSpeed;         // 좌표에 이동할 x,0,z값을 저장
        movement.y = yValue;

        movement.y += Physics.gravity.y * gravityValue * Time.deltaTime;

        GroundCheck();      // 바닥인지 판별하는 함수

        if (isGrounded) 
        {
            movement.y = 0;
            Debug.Log("현재 플레이어가 땅에 있는 상태입니다.");
        } 
        // 점프 구현
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            movement.y = jumpPower;
        }

        if (moveAmount > 0)
        {
            targetRotation = Quaternion.LookRotation(moveDirection);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, smoothRotation);
        player.Move(movement * Time.deltaTime);
        playerAnimator.SetFloat("moveAmount", moveAmount, 0.2f, Time.deltaTime);
    }
    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
    }
}

    

