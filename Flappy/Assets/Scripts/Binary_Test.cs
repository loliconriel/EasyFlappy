using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;

public class Binary_Test : MonoBehaviour
{
    private string EncryptKey = "00001111222233334444555566667777";

    private string path;

    public int Now_Score;
    [Serializable]
    public class Player
    {
        public int Score;
    }
    private void Awake()
    {
        path = Application.persistentDataPath + "/Player_Save.txt";
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Binary_Save();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Binary_Load();
        }
    }

    void Binary_Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Create(path);
        Player player = new Player();
        player.Score = Now_Score;
        bf.Serialize(fileStream, player);
        fileStream.Close();
        Debug.Log("Binary 存檔完成");
    }
    void Binary_Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Open(path, FileMode.Open);
        Player player = (Player)bf.Deserialize(fileStream);
        Now_Score = player.Score;
        fileStream.Close();
        Debug.Log("Binary 讀檔完成");
    }
}

