using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;
    public UserInfo userInfo;
    private String filePath;

    public List<UserData> dataList = new List<UserData>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        filePath = Application.persistentDataPath + "/userDataTxt.text";
        LoadUserData();
    }
    public void SaveUserData()
    {
        Debug.Log(Application.persistentDataPath);
        string saveData = JsonUtility.ToJson(new Serialization<UserData>(dataList), true);
        File.WriteAllText(filePath, saveData);
    }
    public void LoadUserData()
    {
        if (File.Exists(filePath))
        {
            string saveData = File.ReadAllText(filePath);
            dataList = JsonUtility.FromJson<Serialization<UserData>>(saveData).target;
        }
    }
}
