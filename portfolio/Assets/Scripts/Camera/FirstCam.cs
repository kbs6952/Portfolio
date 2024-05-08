using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First : MonoBehaviour
{
    [Header("1��Īī�޶� ���� ����")]
    [SerializeField] Transform playerHead;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private int limitAngle;

    // �÷��̾���� �����̼�x�� �����̸� ������ �¿��̵�
    // �÷��̾� ��� �����̼� z�� �����̸� ������ �����̵�
    float rotationX;
    float rotationY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FirstCamControl();
    }
    private void FirstCamControl()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;        // ���콺�Է°�(��ġ)�� ������ ���� 2��
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

       
        rotationX -= mouseY;                                                 // �����̵�
        rotationX = Mathf.Clamp(rotationX, -limitAngle, limitAngle);


        rotationY += mouseX;                                                // �¿��̵�

        playerHead.rotation = Quaternion.Euler(rotationX, rotationY,0 );

        transform.position = playerHead.position;
        transform.rotation = playerHead.rotation;

    }
}
