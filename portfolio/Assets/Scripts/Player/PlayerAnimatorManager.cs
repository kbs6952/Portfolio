using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    PlayerManager playerManager;

    [Header("애니메이션 제어 변수")]
    private Animator animator;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
    }

    // 애니메이션 클립을 호출하여 각 Manager에서 애니메이션을 쉽게 호출할 수 있게 캡슐화한 함수

    public void PlayerTargetActionAnimation(string actionName, bool isPerformingAction, bool applyRootMotion = true, bool canRotate = false, bool canMove = false)
    {
        animator.CrossFade(actionName, 0.2f);
        playerManager.isPerformingAction = isPerformingAction;
        playerManager.applyRootMotion = applyRootMotion;
        playerManager.canRotate = canRotate;
        playerManager.canMove = canMove;
    }
}
