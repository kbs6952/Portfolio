using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // �÷��̾ �����Ҷ� ������ ����(����)�� = ��ġ����(transform),

    public static SaveManager Instance;

    DataHandler dataHandler;
    GameData gameData;

    [Header("������ ������ ���� ����")]
    public string fileName;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);          // Scene�� ����Ǿ �ı������ʴ� ���� 
    }
    public void NewGame()
    {
        gameData = new GameData();
    }
    private void Start()
    {
        dataHandler = new DataHandler(Application.persistentDataPath,fileName);         // Application.persistentDataPath. ���� : �÷����� ������� ������ �� �ִ�.

        LoadGame();
    }
    public void SaveGame()
    {
        dataHandler.SaveData(gameData);
        //PlayerManager.instance.SaveData(ref gameData);
        Debug.Log("������ ����Ǿ����ϴ�");
    }
    public void LoadGame()
    {
        
       
        Debug.Log("������ �ҷ��ɴϴ�.");
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
