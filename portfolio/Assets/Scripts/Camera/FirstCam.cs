using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First : MonoBehaviour
{
    [Header("1인칭카메라 제어 변수")]
    [SerializeField] Transform playerHead;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private int limitAngle;

    // 플레이어헤드 로테이션x가 움직이면 시점이 좌우이동
    // 플레이어 헤드 로테이션 z가 움직이면 시점이 상하이동
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

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;        // 마우스입력값(위치)을 저장할 변수 2개
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

       
        rotationX -= mouseY;                                                 // 상하이동
        rotationX = Mathf.Clamp(rotationX, -limitAngle, limitAngle);


        rotationY += mouseX;                                                // 좌우이동

        playerHead.rotation = Quaternion.Euler(rotationX, rotationY,0 );

        transform.position = playerHead.position;
        transform.rotation = playerHead.rotation;

    }
}
