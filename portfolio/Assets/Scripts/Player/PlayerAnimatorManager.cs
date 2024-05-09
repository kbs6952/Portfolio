using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    PlayerManager playerManager;

    [Header("�ִϸ��̼� ���� ����")]
    private Animator animator;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
    }

    // �ִϸ��̼� Ŭ���� ȣ���Ͽ� �� Manager���� �ִϸ��̼��� ���� ȣ���� �� �ְ� ĸ��ȭ�� �Լ�

    public void PlayerTargetActionAnimation(string actionName, bool isPerformingAction, bool applyRootMotion = true, bool canRotate = false, bool canMove = false)
    {
        animator.CrossFade(actionName, 0.2f);
        playerManager.isPerformingAction = isPerformingAction;
        playerManager.applyRootMotion = applyRootMotion;
        playerManager.canRotate = canRotate;
        playerManager.canMove = canMove;
    }
}
