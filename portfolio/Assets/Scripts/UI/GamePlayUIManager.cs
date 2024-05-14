using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUIManager : MonoBehaviour
{
    [SerializeField] private GameObject parentObjSetting;
    private GameObject SettingPrefab;


    private bool isOpen = false;       // true�̸� UIManager�� ȣ�� false�̸� �ݴ´�.


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isOpen = !isOpen;
            CallSettingUI(isOpen);
        }

    }
    private void CallSettingUI(bool isOpen)
    {
        parentObjSetting.SetActive(isOpen);
    }
    public void ReturnToLobby()
    {
        LoadingUIManager.LoadScene("TitleScene");
    }

}