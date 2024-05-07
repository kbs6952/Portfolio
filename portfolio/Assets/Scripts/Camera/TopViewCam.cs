using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopViewCam : MonoBehaviour
{
    [Header("카메라 제어 변수")]
    [SerializeField] private Transform playerTr;
    [SerializeField] private float camFollowingSpeed;

    Vector3 offset;
    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Start()
    {
        offset = transform.position-playerTr.position;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void LateUpdate()
    {
        TopViewCamControl();
        
    }
    private void TopViewCamControl()
    {
        Vector3 targetDistance = transform.position - offset;
        transform.position = playerTr.position + offset;
        Vector3.Lerp(transform.position, targetDistance, camFollowingSpeed*Time.deltaTime);
        offset = transform.position - playerTr.position;
       
    }
}
