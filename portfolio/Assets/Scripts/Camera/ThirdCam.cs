using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCam : MonoBehaviour
{
    [Header("3인칭 카메라 제어 변수")]
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

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);     // playerTr이 아닌 따로 var targetRotation을 만든 이유는 playerTr.Rotation을 쓰면 플레이어의 로테이션값이 변화하기때문
                                                                            // (캐릭터가 카메라 시점에 따라 회전하게됨)

        transform.rotation = targetRotation;

        transform.position = playerTr.position - targetRotation * new Vector3(0, -2, camdistance);

        
    }
    private void LateUpdate()
    {

        
    }
}
