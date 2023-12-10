using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class volumeData
{
    [SerializeField] private float _SFXVolume;
    [SerializeField] private float _musicVolume;

    public volumeData(float SFX, float music)
    {
        _SFXVolume = SFX;
        _musicVolume = music;
    }

    public void setSFXVolume(float volume)
    {
        _SFXVolume = volume;
    }

    public void setMusicVolume(float volume)
    {
        _musicVolume = volume;
    }

    public float getSFXAudio()
    {
        return _SFXVolume;
    }
    public float getMusicAudio()
    {
        return _musicVolume;
    }
}
