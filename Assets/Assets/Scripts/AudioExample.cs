using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioExample : MonoBehaviour
{
    [SerializeField] private AudioClip newAudio;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    private void PlaySound(){
        audioSource.Play();
    }

    private void PlaySoundOneShot(AudioClip newAudioClip){
        audioSource.PlayOneShot(newAudioClip);
    }

    private void ChangeAudioClip(AudioClip newAudioClip){
        audioSource.Stop();
        audioSource.clip = newAudioClip;
        audioSource.Play();
    }

    private void PlayLoop(bool loop){
        audioSource.loop = loop;
    }
}