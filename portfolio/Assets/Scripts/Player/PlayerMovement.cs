using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    PlayerMovement playerMovement;

    [Header("플레이어 움직임 제어 변수")]
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private CharacterController player;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        player = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
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

        player.Move(playerMoveInput * playerMoveSpeed * Time.deltaTime);
            ;

    }
}
