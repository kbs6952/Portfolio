using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
=======
>>>>>>> 9cd17d599141f8c88aa5ad9cb02a44100293c6db
using UnityEngine.UI;

public class GamePlayUIManager : MonoBehaviour
{
    [SerializeField] private GameObject parentObjSetting;
    private GameObject SettingPrefab;

<<<<<<< HEAD
    private bool isOpen = false;       // true이면 UIManager를 호출 false이면 닫는다.


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
=======
>>>>>>> 9cd17d599141f8c88aa5ad9cb02a44100293c6db
}