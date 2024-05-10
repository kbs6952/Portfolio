using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    
    public void GameStart()
    {
        LoadingUIManager.LoadScene("SampleScene");
    }
    public void GameQuit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
