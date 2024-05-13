using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataHandler
{
    private string directoryPath = "";
    private string fileName = "";

    public DataHandler(string directoryPath, string fileName)
    {
        this.directoryPath = directoryPath;
        this.fileName = fileName;
    }
    public void SaveData(GameData _data)
    {
        string dataPath = Path.Combine(directoryPath, fileName);

        try
        {
            Debug.Log(dataPath);

            Directory.CreateDirectory(Path.GetDirectoryName(dataPath));
            string serializeData = JsonUtility.ToJson(_data, true);

            using(FileStream stream =new FileStream(dataPath,FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(serializeData);
                }
            }
        }
        catch(Exception e)
        {
            Debug.LogError("에러 발생" + dataPath + "\n" + e);
        }
    }
    //public GameData LoadData()
    //{

    //}
}
