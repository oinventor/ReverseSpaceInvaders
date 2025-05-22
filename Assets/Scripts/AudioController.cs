using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //This is a singleton. Basicly it makes callint functions on classes easyer. But be carefull, it only works if this
    //script remain the only one of its kind!!!
    public static AudioController audioController;
    [SerializeField] private AudioSource audioSourceOBJ;
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
}
