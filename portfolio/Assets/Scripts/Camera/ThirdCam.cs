using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCam : MonoBehaviour
{
    [Header("3��Ī ī�޶� ���� ����")]
    [SerializeField] private float camdistance;
    [SerializeField] private Transform playerTr;
    [SerializeField] private float mouseSpeed;
    [SerializeField] private int limitAngle;

    float rotationX;
    float rotationY;

    public Quaternion camLookRotation => Quaternion.Euler(0, rotationY, 0);
    void Start()
    {
        
    }

    
    void Update()
    {
        ThirdCamControl();   
    }
    private void ThirdCamControl()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -limitAngle, limitAngle);

        rotationY += mouseX;

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);     // playerTr�� �ƴ� ���� var targetRotation�� ���� ������ playerTr.Rotation�� ���� �÷��̾��� �����̼ǰ��� ��ȭ�ϱ⶧��
                                                                            // (ĳ���Ͱ� ī�޶� ������ ���� ȸ���ϰԵ�)

        transform.rotation = targetRotation;

        transform.position = playerTr.position - targetRotation * new Vector3(0, -2, camdistance);

        
    }
    private void LateUpdate()
    {

        
    }
}
