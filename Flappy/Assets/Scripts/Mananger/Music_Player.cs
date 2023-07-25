using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music_Player : MonoBehaviour
{
    static public Music_Player instance;
    public AudioClip[] audioClips = new AudioClip[2];
    public AudioMixer audioMixer;
    int Now_Play = 0;
    private void Awake()
    {
        //¨¾¤îª«¥ó³Q§R
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        GetComponent<AudioSource>().clip = audioClips[Now_Play];
        GetComponent<AudioSource>().Play();
    }
    private void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            Now_Play++;
            if(Now_Play >= audioClips.Length)
            {
                Now_Play = 0;
            }
            GetComponent<AudioSource>().clip = audioClips[Now_Play];
            GetComponent<AudioSource>().Play();
        }
    }
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume",volume);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }
    public void SetEffectVolume(float volume)
    {
        audioMixer.SetFloat("EffectVolume", volume);
    }
    public float GetMasterVolume()
    {
        float volume;
        audioMixer.GetFloat("MasterVolume",out volume);
        return volume;
    }
    public float GetMusicVolume()
    {
        float volume;
        audioMixer.GetFloat("MusicVolume", out volume);
        return volume;
    }
    public float GetEffectVolume()
    {
        float volume;
        audioMixer.GetFloat("EffectVolume", out volume);
        return volume;
    }
}
