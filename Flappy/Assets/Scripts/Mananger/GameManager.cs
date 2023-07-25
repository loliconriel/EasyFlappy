using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    public GameObject Setting_Buttonn;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            Setting_Buttonn.SetActive(true);
        }
    }
    public void FullScreen(bool check)
    {
        Screen.fullScreen = check;
    }
    public void Frame(string s)
    {
        int frame;
        int.TryParse(s, out frame);
        Application.targetFrameRate = frame;
    }
    public void resoltion(int width,int height)
    {
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
}
