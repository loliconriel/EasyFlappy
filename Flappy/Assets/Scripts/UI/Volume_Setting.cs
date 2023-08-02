using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Volume_Setting : MonoBehaviour
{
    private GameObject Manager;
    private Slider slider;
    void Start()
    {
        Manager = GameObject.Find("Music_Player");
        slider = GetComponent<Slider>();
        switch (gameObject.name)
        {
            case "Master":
                slider.value = Manager.GetComponent<Music_Player>().GetMasterVolume();
                slider.onValueChanged.AddListener(Manager.GetComponent<Music_Player>().SetMasterVolume);
                break;
            case "Music":
                slider.value = Manager.GetComponent<Music_Player>().GetMusicVolume();
                slider.onValueChanged.AddListener(Manager.GetComponent<Music_Player>().SetMusicVolume);
                break;
            case "Effect":
                slider.value = Manager.GetComponent<Music_Player>().GetEffectVolume();
                slider.onValueChanged.AddListener(Manager.GetComponent<Music_Player>().SetEffectVolume);
                break;
            default:
                break;
        }
    }


}
