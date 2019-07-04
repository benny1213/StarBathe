﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StringReadWriteTest : MonoBehaviour
{
    [SerializeField] string filePath = "stringSaveData.csv";
    [SerializeField] bool usePersistentDataPath = false;
    private List<string> dataList;

    // Use this for initialization
    void Start()
    {
        dataList = readData(filePath);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        writeData(filePath, dataList);
    }

    private List<string> readData(string _path)
    {
        List<string> _dataList = new List<string>();
        string path = _path;
        if (usePersistentDataPath)
        {
            path = Application.persistentDataPath + "/" + path;
        }
        Debug.Log(path);
        if (System.IO.File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);
            int cnt = 0;
            while (sr.Peek() > -1)
            {
                cnt++;
                string lineStr = sr.ReadLine();
                if (!lineStr.StartsWith("//", System.StringComparison.CurrentCulture))
                {
                    string reData = reCreateData(lineStr);
                    _dataList.Add(reData);
                    Debug.Log(">" + cnt);
                }
            }
            sr.Close();
            Debug.Log("real");
        }
        else
        {
            for (int i = 0; i < 10; ++i)
            {
                _dataList.Add("0,1,2,3,4,5,6,7,8,9");
            }
            Debug.Log("0123456789");
        }
        Debug.Log("readed");
        return _dataList;
    }

    private bool writeData(string _path, List<string> _dataList)
    {
        bool ret = false;
        string path = "out_" + _path;
        if (usePersistentDataPath)
        {
            path = Application.persistentDataPath + "/" + path;
        }
        StreamWriter sw = new StreamWriter(path);
        foreach (string data in _dataList)
        {
            sw.WriteLine(data);
        }
        sw.Flush();
        sw.Close();
        return ret;
    }

    private string reCreateData(string _dataStr)
    {
        string[] dataArr = _dataStr.Split('|');
        string data = "";
        string hipId = dataArr[4];
        string[] rkd = dataArr[1].Split(' ');
        string[] rid = dataArr[2].Split(' ');
        string mag = dataArr[5];
        string palla = dataArr[3];
        string vbcol = dataArr[6];

        int id = 0;
        int.TryParse(hipId, out id);
        float fKdH = 0f;
        float fKdM = 0f;
        float fKdS = 0f;
        float.TryParse(rkd[0], out fKdH);
        float.TryParse(rkd[1], out fKdM);
        float.TryParse(rkd[2], out fKdS);
        int iKdSGN = rid[0].Substring(0, 1) == "+" ? 1 : 0;
        float fidD = 0f;
        float fidM = 0f;
        float fidS = 0f;
        float.TryParse(rid[0], out fidD);
        float.TryParse(rid[1], out fidM);
        float.TryParse(rid[2], out fidS);
        float vmag = 0f;
        float.TryParse(mag, out vmag);
        float iPara = 0f;
        float.TryParse(palla, out iPara);
        float vb = 0f;
        float.TryParse(vbcol, out vb);

        data = "";
        data += id.ToString() + ",";
        data += fKdH.ToString() + ",";
        data += fKdM.ToString() + ",";
        data += fKdS.ToString() + ",";
        data += iKdSGN.ToString() + ",";
        data += (Mathf.Abs(fidD)).ToString() + ",";
        data += fidM.ToString() + ",";
        data += fidS.ToString() + ",";
        data += vmag.ToString() + ","; // 8
        data += iPara.ToString() + ","; // 9
        data += "0,0,";
        data += vb.ToString() + ","; // 12
        return data;
    }
}