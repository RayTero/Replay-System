using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DataCollectionSaver : MonoBehaviour
{
    public static DataCollectionSaver instance;
    private Player player;
    [SerializeField] private DataCollection saveData;

    private void Awake()
    {
        saveData =  new DataCollection();
        CreateInstance();
    }

    void CreateInstance()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void OnApplicationQuit()
    {
        if (!InputManager.instance.replayMode)
        {
            SaveData();
        }
    }

    //private void Start()
    //{
    //    player = FindObjectOfType<Player>();


    //    saveData.m_playerPos.Add(player.PlayerPos);
    //    saveData.m_playerRotation.Add(player.PlayerRotation);

    //    //check base save folder exists, if not it creates it
    //    if (!System.IO.Directory.Exists($"{GetProjectFolder()}/ZSavedDebugData"))
    //    {
    //        System.IO.Directory.CreateDirectory($"{GetProjectFolder()}/ZSavedDebugData");
    //        Debug.Log($"made directory: {GetProjectFolder()}/ZSavedDebugData");
    //    }

    //    //check if today folder exitst, if not it creates it
    //    if (!System.IO.Directory.Exists($"{GetProjectFolder()}/ZSavedDebugData/{m_today}"))
    //    {
    //        System.IO.Directory.CreateDirectory($"{GetProjectFolder()}/ZSavedDebugData/{m_today}");
    //        Debug.Log($"made directory: {GetProjectFolder()}/ZSavedDebugData/{m_today}");
    //    }

    //    StartCoroutine(Save());
    //}

    public void AddInput(bool [] data)
    {
        saveData.WriteData(data);
    }

    private static string GetProjectFolder()
    {
        string[] s = Application.dataPath.Split('/');
        string projectPath = "";
        for (int i = 0; i < s.Length - 1; i++)
        {
            projectPath += $"{s[i]}\\";
        }
        return projectPath;
    }

    void SaveData()
    {
        string data = JsonConvert.SerializeObject(saveData);

        if (!System.IO.Directory.Exists($"{GetProjectFolder()}/ZSavedDebugData"))
        {
            System.IO.Directory.CreateDirectory($"{GetProjectFolder()}/ZSavedDebugData");
            Debug.Log($"made directory: {GetProjectFolder()}/ZSavedDebugData");
        }

        //check if today folder exitst, if not it creates it
        if (!System.IO.Directory.Exists($"{GetProjectFolder()}/ZSavedDebugData/data"))
        {
            System.IO.Directory.CreateDirectory($"{GetProjectFolder()}/ZSavedDebugData/data");
            Debug.Log($"made directory: {GetProjectFolder()}/ZSavedDebugData/data");
        }

        //check if today folder exitst, if not it creates it
        if (!System.IO.File.Exists($"{GetProjectFolder()}/ZSavedDebugData/data/InputData{DateTime.UtcNow.ToString("hh-mm-ss")}.json"))
        {
            System.IO.File.WriteAllText($"{GetProjectFolder()}/ZSavedDebugData/data/InputData{DateTime.UtcNow.ToString("hh-mm-ss")}.json", data);
            Debug.Log($"made directory: {GetProjectFolder()}/ZSavedDebugData/data/InputData{DateTime.UtcNow.ToString("hh-mm-ss")}.json");
        }
    }
}
