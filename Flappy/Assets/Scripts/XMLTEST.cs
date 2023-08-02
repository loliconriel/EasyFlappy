using Newtonsoft.Json.Schema;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using UnityEngine;
using System;
//using System.Security.Cryptography; 有這個才有 RijndaelManaged
public class XMLTEST : MonoBehaviour
{

    private string EncryptKey = "00001111222233334444555566667777";
    public int Now_Score;
    
    public class Player
    {
        public int Score;
    }

    private string path;
    private void Awake()
    {
        path = Application.persistentDataPath+"/Player_Save.xml";
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {
            XML_Save();
        }
        else if (Input.GetKeyUp(KeyCode.U))
        {
            XML_Load();
        }
        
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
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray,0, toEncryptArray.Length);

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
    void XML_Save()
    {
        Player player = new Player();
        player.Score = Now_Score;

        XmlDocument xml = new XmlDocument();

        XmlDeclaration declaration = xml.CreateXmlDeclaration("1.0","UTF-8","");
        xml.AppendChild(declaration);

        XmlElement root = xml.CreateElement("root");
        xml.AppendChild(root);

        XmlElement score = xml.CreateElement("score");
        score.InnerText = player.Score.ToString();
        root.AppendChild(score);
        
        xml.Save(Application.persistentDataPath + "/Player_Save.xml");
        string xxx = Encrypt(xml.InnerXml);
        StreamWriter writer;
        writer = File.CreateText(path);
        writer.Write(xxx);
        writer.Close();

        Debug.Log("XML 存檔完畢");

    }
    void XML_Load()
    {

        XmlDocument XML = new XmlDocument();

        //XML.Load(path);
        StreamReader sReader = File.OpenText(path);
        string dataString = sReader.ReadToEnd();
        sReader.Close();

        string xxx = Decrypt(dataString);

        XML.LoadXml(xxx);
        XmlNodeList XMLScore = XML.GetElementsByTagName("score");
        int Score = int.Parse(XMLScore[0].InnerText);
        Now_Score = Score;
        Debug.Log("XML 讀檔完畢");
        /*
        if (System.IO.File.Exists(Application.persistentDataPath+"/Player_Save"))
        {
            
        }
        else
        {
            Debug.Log("找不到檔案");
        }
        */

    }

}
