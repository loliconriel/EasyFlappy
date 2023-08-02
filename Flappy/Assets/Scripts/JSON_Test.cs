using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class JSON_Test : MonoBehaviour
{
    private string EncryptKey = "00001111222233334444555566667777";

    private string path;

    public int Now_Score;

    public class Player
    {
        public int Score;
    }
    private void Awake()
    {
        path = Application.persistentDataPath + "/Player_Save.json";
    }
    private string Encrypt(string toE)
    {
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes(EncryptKey);
        Aes rdEL = Aes.Create();
        rdEL.Key = keyArray;
        rdEL.Mode = CipherMode.ECB;
        rdEL.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = rdEL.CreateEncryptor();

        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toE);
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }
    private string Decrypt(string toD)
    {
        byte[] KeyArray = UTF8Encoding.UTF8.GetBytes(EncryptKey);
        //原本是用RijndaelManaged 後來改成Aes
        Aes rdEL = Aes.Create();
        rdEL.Key = KeyArray;
        rdEL.Mode = CipherMode.ECB;
        rdEL.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransfrom = rdEL.CreateDecryptor();

        byte[] toDecryptArray = Convert.FromBase64String(toD);
        byte[] resultArray = cTransfrom.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);

        return UTF8Encoding.UTF8.GetString(resultArray);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            Json_Save();
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            Json_Load();
        }
    }
    private void Json_Save()
    {
        Player player = new Player();
        player.Score = Now_Score;

        string Json_Text = JsonUtility.ToJson(player);
        File.WriteAllText(path, Encrypt(Json_Text));
        Debug.Log("Json 存檔完成");
    }
    private void Json_Load()
    {
        string text = File.ReadAllText(path);
        text = Decrypt(text);
        Player player = JsonUtility.FromJson(text, typeof(Player)) as Player;
        Now_Score = player.Score;
        Debug.Log("Json 讀檔完成");
    }
}
