using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    //This is a singleton. Basicly it makes callint functions on classes easyer. But be carefull, it only works if this
    //script remain the only one of its kind!!!
    public static AudioController audioController;
    [SerializeField] private AudioSource audioSourceOBJ;
    [SerializeField] private AudioMixer mainAudioMixer;
    private void Awake()
    {
        if (audioController == null)
        {
            audioController = this;
        }
    }

    public void PlayAudioClip(AudioClip audioClip, Transform audioTransform, float volume)
    {
        AudioSource audioSource = Instantiate(audioSourceOBJ, audioTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }

    public void SetMasterVolume(float level)
    {
        mainAudioMixer.SetFloat("mastarVolume", Mathf.Log10(level) * 20);
    }
    public void SetMusicVolume(float level)
    {
        mainAudioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20);
    }
    public void SetSFXVolume(float level)
    {
        mainAudioMixer.SetFloat("sfxVolume", Mathf.Log10(level) * 20);
    }
}
