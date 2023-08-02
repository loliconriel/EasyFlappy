using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour
{
    private GameObject gameManager;
    private Toggle toggle;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        toggle = GetComponent<Toggle>();
        toggle.isOn = Screen.fullScreen;
        toggle.onValueChanged.AddListener(gameManager.GetComponent<GameManager>().FullScreen);
    }

}
