using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    //方法一 不必在inspector上將函式掛上去
    private Button Restart_Button;
    void Start()
    {
        Restart_Button = GetComponent<Button>();
        Restart_Button.onClick.AddListener(click);
    }
    private void click()
    {
        SceneManager.LoadScene("Main");
    }
    //方法二 函式必須用public 否則Onclick那邊找不到
    public void Lose()
    {
        SceneManager.LoadScene("Main");
    }
}
