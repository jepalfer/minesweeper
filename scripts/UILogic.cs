using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UILogic : MonoBehaviour
{
    private int _time;
    [SerializeField] private TextMeshProUGUI _timerUI;
    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private GameObject _continueButton;
    private static GameObject _controller;
    [SerializeField] private GameObject _winUI;
    [SerializeField] private GameObject _loseUI;
    [SerializeField] private GameObject _replayLoseButton;
    [SerializeField] private GameObject _replayWinButton;
    private bool _isPaused = false;

    private void Start()
    {
        _time = 0;
        _timerUI.color = Color.blue;
        _timerUI.text = _time.ToString();
        InvokeRepeating("timePass", 0, 1);
        _controller = gameObject;

    }

    public int getTime()
    {
        return _time;
    }

    public void timePass()
    {
        if (!_isPaused)
        {
            _time++;
            _timerUI.text = _time.ToString();
        }
    }

    public static GameObject getController()
    {
        return _controller;
    }

    public void continueButtonPress()
    {
        _isPaused = false;
        _pauseUI.SetActive(false);
    }

    public void exitButtonPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void gameOver(int index)
    {
        if (index == 0)
        {
            Invoke("showLoseUI", 2);
        }
        else
        {
            Invoke("showWinUI", 0.5f);
        }
    }

    public void showLoseUI()
    {
        _isPaused = true;
        EventSystem.current.SetSelectedGameObject(_replayLoseButton);
        _loseUI.SetActive(true);
    }

    public void showWinUI()
    {
        _isPaused = true;
        EventSystem.current.SetSelectedGameObject(_replayWinButton);
        _winUI.SetActive(true);
    }

    public void replayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void selectDifficulty()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;
            _pauseUI.SetActive(!_pauseUI.activeSelf);

            if (_isPaused)
            {
                EventSystem.current.SetSelectedGameObject(_continueButton);
            }
        }
    }
}
