using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sfxPlayer : MonoBehaviour
{
    [SerializeField] GameObject _SFX, _Music;
    [SerializeField] AudioSource _SFXSrc, _musicSrc;
    [SerializeField] AudioClip _explosionSFX, _cleanTileSFX, _flagSFX, _defeatSFX, _winSFX, _gameMusic;
    [SerializeField] private Sprite _muteMusic, _onMusic, _muteSFX, _onSFX;
    [SerializeField] Image _musicImage, _SFXImage;

    private void Start()
    {
        volumeData data = saveSystem.loadVolume();
        if (data == null)
        {
            saveSystem.saveVolume(100, 100);
            data = saveSystem.loadVolume();
        }
        _SFXSrc = Instantiate(_SFX).GetComponent<AudioSource>();
        _musicSrc = Instantiate(_Music).GetComponent<AudioSource>();
        _SFXSrc.mute = false;
        _musicSrc.mute = false;
        _SFXSrc.volume = Mathf.Pow((data.getSFXAudio() / 100), 2);
        _musicSrc.volume = Mathf.Pow((data.getMusicAudio() / 100), 2);
        _musicSrc.clip = _gameMusic;
        _musicSrc.loop = true;
        _musicSrc.Play();
    }
    public void changeSFXSrcVolume(Slider volume)
    {
        _SFXSrc.volume = volume.value;
    }
    public void changeMusicSrcVolume(Slider volume)
    {
        _musicSrc.volume = volume.value;
    }

    public void unPauseMusic()
    {
        _musicSrc.UnPause();
    }

    public void playMusic()
    {
        _musicSrc.Play();
    }

    public void playWinSFX()
    {
        _SFXSrc.clip = _winSFX;
        _SFXSrc.Play();
    }

    public void playDefeatSFX()
    {
        _SFXSrc.clip = _defeatSFX;
        _SFXSrc.Play();
    }

    public void stopMusic()
    {
        _musicSrc.Stop();
    }

    public void playFlagSFX()
    {
        _SFXSrc.clip = _flagSFX;
        _SFXSrc.Play();
    }

    public void playExplosion()
    {
        _SFXSrc.clip = _explosionSFX;
        _SFXSrc.Play();
    }

    public void playClean()
    {
        _SFXSrc.clip = _cleanTileSFX;
        _SFXSrc.Play();
    }

    public void muteMusic()
    {
        _musicSrc.mute = !_musicSrc.mute;

        if (_musicSrc.mute)
        {
            _musicImage.sprite = _muteMusic;
        }
        else
        {
            _musicImage.sprite = _onMusic;
        }
    }
    public void muteSFX()
    {
        _SFXSrc.mute = !_SFXSrc.mute;

        if (_SFXSrc.mute)
        {
            _SFXImage.sprite = _muteSFX;
        }
        else
        {
            _SFXImage.sprite = _onSFX;
        }
    }

    public AudioSource getSFXSource()
    {
        return _SFXSrc;
    }
    public AudioSource getMusicSource()
    {
        return _musicSrc;
    }
}
