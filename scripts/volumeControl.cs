using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class volumeControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _musicText;
    [SerializeField] private TextMeshProUGUI _SFXText;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _SFXSlider;
    [SerializeField] private Button _backButton;

    private void Start()
    {
        volumeData data = saveSystem.loadVolume();

        if (data == null)
        {
            saveSystem.saveVolume(100, 100);
        }
        else
        {
            _SFXText.text = data.getSFXAudio().ToString();
            _musicText.text = data.getMusicAudio().ToString();
            calculateSFXSliderPosition(data.getSFXAudio());
            calculateMusicSliderPosition(data.getMusicAudio());
        }
    }


    public void changeSFXVolume()
    {
        _SFXText.text = (calculateSFXVolume()).ToString();
        saveSystem.saveVolume(calculateSFXVolume(), calculateMusicVolume());
    }

    public void changeMusicVolume()
    {
        _musicText.text = (calculateMusicVolume()).ToString();
        saveSystem.saveVolume(calculateSFXVolume(), calculateMusicVolume());
    }

    public int calculateSFXVolume()
    {
        return Mathf.RoundToInt(Mathf.Sqrt(_SFXSlider.value) * 100);
    }

    public int calculateMusicVolume()
    {
        return Mathf.RoundToInt(Mathf.Sqrt(_musicSlider.value) * 100);
    }

    public void calculateSFXSliderPosition(float volume)
    {
        _SFXSlider.value = Mathf.Pow((volume / 100), 2);
    }
    public void calculateMusicSliderPosition(float volume)
    {
        _musicSlider.value = Mathf.Pow((volume / 100), 2);
    }

    public void back()
    {
        gameObject.SetActive(false);
    }
}
