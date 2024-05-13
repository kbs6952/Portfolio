using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // 플레이어를 저장할때 들어가야할 변수(정보)들 = 위치정보(transform),

    public static SaveManager Instance;

    DataHandler dataHandler;
    GameData gameData;

    [Header("저장할 데이터 변수 정보")]
    public string fileName;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);          // Scene이 변경되어도 파괴되지않는 설정 
    }
    public void NewGame()
    {
        gameData = new GameData();
    }
    private void Start()
    {
        dataHandler = new DataHandler(Application.persistentDataPath,fileName);         // Application.persistentDataPath. 장점 : 플랫폼에 상관없이 저장할 수 있다.

        LoadGame();
    }
    public void SaveGame()
    {
        dataHandler.SaveData(gameData);
        //PlayerManager.instance.SaveData(ref gameData);
        Debug.Log("게임이 저장되었습니다");
    }
    public void LoadGame()
    {
        
       
        Debug.Log("게임을 불러옵니다.");
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
