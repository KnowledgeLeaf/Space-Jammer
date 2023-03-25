using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_musicAudioSource;
    [SerializeField] private AudioSource m_soundFXAudioSource;
    private AudioClip m_Clip;
    private List<AudioClip> m_AudioClipList;

    private void Start()
    {
        m_musicAudioSource = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        m_soundFXAudioSource = transform.GetChild(1).gameObject.GetComponent<AudioSource>();
    }

    public void MusicVolume(float value)
    {
        m_musicAudioSource.volume = value;
    }
    public void MusicPlay(AudioClip clip)
    {
        m_musicAudioSource.clip = clip;
        m_musicAudioSource.Play();
    }
    public void MusicPlay(float value, AudioClip clip)
    {
        m_musicAudioSource.volume = value;
        m_musicAudioSource.clip = clip;
        m_musicAudioSource.Play();
    }

    public void SoundFXVolume(float value)
    {
        m_soundFXAudioSource.volume = value;
    }
    public void SoundFXPlay(AudioClip clip)
    {
        m_soundFXAudioSource.clip = clip;
        m_soundFXAudioSource.Play();
    }
    public void SoundFXPlay(float value, AudioClip clip)
    {
        m_soundFXAudioSource.volume = value;
        m_soundFXAudioSource.clip = clip;
        m_soundFXAudioSource.Play();
    }
}
