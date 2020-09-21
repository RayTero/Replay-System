using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ReadBackData : MonoBehaviour
{
    int frame = 0;
    DataCollection replayData;
    [SerializeField] private string fileName;

    // Start is called before the first frame update
    void Start()
    {
        ReadBackCollectedData();
    }

    // Update is called once per frame
    void Update()
    {
        if (replayData != null)
        {
            if(frame < replayData.input.Count)
            InputManager.instance.SetDirections(replayData.input[frame]);
        }
        frame++;
    }

    void ReadBackCollectedData()
    {
        string data = System.IO.File.ReadAllText($"{GetProjectFolder()}/ZSavedDebugData/data/{fileName}.json");
        replayData = JsonConvert.DeserializeObject<DataCollection>(data);
        Debug.Log(replayData);
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
}
