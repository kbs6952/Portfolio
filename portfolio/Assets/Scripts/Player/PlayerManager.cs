using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [Header("Common Player Data")]
    [HideInInspector] public CharacterController characterController;
    [HideInInspector] public Animator animator;

    [Header("�÷��̾� ���� ����")]
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
    public void SaveData(ref GameData gameData)         // gameData�� ���� ��ġ������ ����
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
