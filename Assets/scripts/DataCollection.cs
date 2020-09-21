using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;



[Serializable]
public class DataCollection
{
    public List<bool[]> input;

    public DataCollection()
    {
        input = new List<bool[]>();
    }

    public void WriteData(bool[] data)

    {
        bool[] newData = new bool[4];
        data.CopyTo(newData, 0);
        input.Add(newData);
    }
}
