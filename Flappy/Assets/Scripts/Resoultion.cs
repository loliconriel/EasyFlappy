using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resoultion : MonoBehaviour
{
    private GameObject gameManager;
    private TMP_Dropdown resolution;
    Resolution[] resolutions;
    List<string> resolutionList = new List<string>();
    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        resolution = GetComponent<TMP_Dropdown>();
        resolutions = Screen.resolutions;

        resolution.ClearOptions();
        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionList.Add(ResToString(resolutions[i]));
        }
        resolution.AddOptions(resolutionList);
        
        
        for(int i = 0; i < resolutionList.Count; i++)
        {
            if (Screen.width.ToString()+"x"+Screen.height.ToString() == ResToString(resolutions[i]))
            {
                resolution.value = i;
                break;
            }
        }
        
        resolution.RefreshShownValue();
        
        resolution.onValueChanged.AddListener(delegate {  change(resolution.value); });
    }
    void change(int s)
    {
        gameManager.GetComponent<GameManager>().resoltion(resolutions[s].width, resolutions[s].height);
    }
    string ResToString(Resolution res)
    {
        return res.width + "x" +res.height;
    }
}
