using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    public GameObject Setting_Buttonn;
    private TextMeshProUGUI NowScore;
    public TextMeshProUGUI BestScore;
    public GameObject Record;
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

    public void Lose(int score)
    {
        NowScore = GameObject.Find("Now_Score").GetComponent<TextMeshProUGUI>();
        BestScore = GameObject.Find("Best_Score").GetComponent<TextMeshProUGUI>();
        Record = GameObject.Find("New");
        if(score > PlayerPrefs.GetInt("BestScore")){
            PlayerPrefs.SetInt("BestScore", score);
            Record.SetActive(true);
        }
        else Record.SetActive(false);
        NowScore.text = score.ToString();
        BestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        PlayerPrefs.Save();
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
