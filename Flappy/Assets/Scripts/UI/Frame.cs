using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Frame : MonoBehaviour
{
    private GameObject gameManager;
    private TMP_InputField Inputfield;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        Inputfield = GetComponent<TMP_InputField>();
        Inputfield.onEndEdit.AddListener(gameManager.GetComponent<GameManager>().Frame);
    }


}
