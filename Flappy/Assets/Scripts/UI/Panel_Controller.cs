using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Controller : MonoBehaviour
{
    public GameObject panel;
    public void click()
    {
        panel.SetActive(!panel.activeSelf);
    }
}
