using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    //��k�@ �����binspector�W�N�禡���W�h
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
    //��k�G �禡������public �_�hOnclick����䤣��
    public void Lose()
    {
        SceneManager.LoadScene("Main");
    }
}
