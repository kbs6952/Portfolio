using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [Header("Common Player Data")]
    [HideInInspector] public CharacterController characterController;
    [HideInInspector] public Animator animator;

    [Header("플레이어 제약 조건")]
    public bool isPerformingAction = false;
    public bool applyRootMotion = false;
    public bool canRotate = true;
    public bool canMove = true;
    public bool canCombo = false;

    [Header("Player Manager Scripts")]
    [HideInInspector] public PlayerAnimatorManager playerAnimatorManager;
    [HideInInspector] public PlayerMovementManager playerMovementManager;
    private void Awake()
    {
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
        playerMovementManager = GetComponent<PlayerMovementManager>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    public void SaveData(ref GameData gameData)         // gameData에 현재 위치정보를 저장
    {
        gameData.x = transform.position.x;
        gameData.y = transform.position.y;
        gameData.z = transform.position.z;
    }
    public void LoadData(GameData saveData)
    {
        Vector3 loadPlayerPos = new Vector3 (saveData.x, saveData.y, saveData.z);
        transform.position = loadPlayerPos;
    }
}
