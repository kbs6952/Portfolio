using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementManager : MonoBehaviour
{
    PlayerManager playerManager;

    [Header("플레이어 매니저 스크립트")]
    [HideInInspector] public PlayerAnimatorManager playerAnimatorManager;

    PlayerMovementManager playerMovement;

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
        playerManager = GetComponent<PlayerManager>();
        playerAnimator = GetComponent<Animator>();
        player = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleComboAttack();
        HandleActionInput();
    }
    private void HandleMovement()
    {
        if (playerManager.isPerformingAction) return;           // 플레이어가 액션중일땐 움직일 수 없음.

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
            moveAmount++;
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
        } 
        // 점프 구현
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerAnimator.CrossFade("Jump", 0.2f);
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
        playerAnimator.SetBool("isGround", isGrounded);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
    }

    private void HandleActionInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            HandleAttackAction();
        }
    }

    private void HandleAttackAction()
    {
        playerManager.playerAnimatorManager.PlayerTargetActionAnimation("ATK0", true);
        playerManager.canCombo = true;
    }
    private void HandleComboAttack()
    {
        if (!playerManager.canCombo) return;

        if (Input.GetMouseButtonDown(0))
        {
            playerAnimator.SetTrigger("doAttack");
        }
    }
    private void SheildParrying()       // 방패 패링 구현(아직x)
    {
        if (Input.GetMouseButtonDown(1))
        {
           // playerAnimator.CrossFade("Parry",0.2f); 이런식으로 구현?
        }
    }

}

    

