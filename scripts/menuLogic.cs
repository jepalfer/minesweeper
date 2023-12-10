using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class menuLogic : MonoBehaviour
{
    [SerializeField] private GameObject _timeTrialLeaderBoard;
    [SerializeField] private GameObject _leaderBoardPanel;
    [SerializeField] private GameObject _configurationPanel;
    [SerializeField] private AudioSource _musicSrc;

    private void Start()
    {
        volumeData data = saveSystem.loadVolume();

        if (data != null)
        {
            _musicSrc.volume = data.getMusicAudio();
        }
        _musicSrc.time = globalVariables.getTimeMusicPlayed();
    }

    public void setMusicSrcAudio(Slider music)
    {
        _musicSrc.volume = music.value;
    }
    public void playGame()
    {
        globalVariables.setTimeMusicPlayed(_musicSrc.time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void back()
    {
        _leaderBoardPanel.SetActive(false);
        _timeTrialLeaderBoard.SetActive(false);
        _configurationPanel.SetActive(false);
    }
    public void showLeaderBoard()
    {
        _timeTrialLeaderBoard.SetActive(false);
        _leaderBoardPanel.SetActive(true);
    }


    public void showConfigurationPanel()
    {
        _configurationPanel.SetActive(true);
    }

    public void showTimeTrialLeaderBoard()
    {
        _timeTrialLeaderBoard.SetActive(true);
        _leaderBoardPanel.SetActive(false);
    }
}
