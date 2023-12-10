using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelSelectLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _easyText;
    [SerializeField] private TextMeshProUGUI _mediumText;
    [SerializeField] private TextMeshProUGUI _hardText;
    [SerializeField] private TextMeshProUGUI _extremeText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _difficultyText;
    [SerializeField] private Button _extremeButton;
    [SerializeField] private Image _unlockImage;
    [SerializeField] private TMP_Dropdown _dropDown;
    [SerializeField] private Toggle _timeTrialToggle;
    [SerializeField] private AudioSource _musicSrc;
    private victoriesData data;
    private int _diffIndex = 0;
    private float _easyMult = 0.1f;
    private float _mediumMult = 0.2f;
    private float _hardMult = 0.27f;
    private float _extremeMult = 0.35f;
    private const int _MAPSIZEDIFFERENCE = 5;

    private void Start()
    {
        volumeData data = saveSystem.loadVolume();

        if (data != null)
        {
            _musicSrc.volume = data.getMusicAudio();
        }
        _musicSrc.time = globalVariables.getTimeMusicPlayed();
        globalVariables.setTimeTrial(false);
        globalVariables.setGameDifficulty(difficultyLevel.EASY);
        globalVariables.setRows(5);
        globalVariables.setBombsQuantity(getNumberOfBombs(_easyMult));
        //victoriesData data = saveSystem.loadVictories();
        data = saveSystem.loadVictories();
        if (data != null)
        {
            unlockExtreme(data);
        }
        setTexts(5);

        /*
        victoriesData data = saveSystem.loadVictories();
        if (data != null)
        {
            bool extremeUnlock = true;
            for (int i = 0; i < 3; i++)
            {
                if (data.get7x7Victories()[i] == 0)
                {
                    extremeUnlock = false;
                    break;
                }
            }
            if (extremeUnlock)
            {
                _extremeButton.enabled = true;
                _unlockImage.enabled = false;
                _extremeText.text = "EXTREMO\n" + getNumberOfBombs(_extremeMult).ToString() + " BOMBAS";
            }
            else
            {
                _extremeButton.enabled = false;
                _unlockImage.enabled = true;
            }
        }*/
    }

    public void onToggleCheck()
    {
        globalVariables.setTimeTrial(_timeTrialToggle.isOn);
    }

    public void onDropDownSelect()
    {
        int numOfRows = _dropDown.value + _MAPSIZEDIFFERENCE;
        globalVariables.setRows(numOfRows);
        setTexts(numOfRows);
        //victoriesData data = saveSystem.loadVictories();
        if (data != null)
        {
            unlockExtreme(data);
        }
        setDifficulty();
    }

    public void setTexts(int mapSize)
    {
        _levelText.text = mapSize.ToString() + "x" + mapSize.ToString();
        _easyText.text = "FÁCIL\n" + getNumberOfBombs(_easyMult).ToString() + " BOMBAS";
        _mediumText.text = "MEDIO\n" + getNumberOfBombs(_mediumMult).ToString() + " BOMBAS";
        _hardText.text = "DIFÍCIL\n" + getNumberOfBombs(_hardMult).ToString() + " BOMBAS";
    }

    public void setDifficulty()
    {
        if (_diffIndex == 0)
        {
            globalVariables.setBombsQuantity(getNumberOfBombs(_easyMult));
        }
        else if (_diffIndex == 1)
        {
            globalVariables.setBombsQuantity(getNumberOfBombs(_mediumMult));
        }
        else if (_diffIndex == 2)
        {
            globalVariables.setBombsQuantity(getNumberOfBombs(_hardMult));
        }
        else
        {
            globalVariables.setBombsQuantity(getNumberOfBombs(_hardMult));
        }
    }
    public void playGame()
    {
        globalVariables.setTimeMusicPlayed(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void setDefaultMap(int index)
    {
        //victoriesData data = saveSystem.loadVictories();
        switch (index)
        {
            case 0:
                globalVariables.setRows(7);
                setTexts(7);

                if (data != null)
                {
                    unlockExtreme(data);
                }
                setDifficulty();
                break;

            case 1:
                globalVariables.setRows(15); 
                setTexts(15);
                if (data != null)
                {
                    unlockExtreme(data);
                }
                setDifficulty();
                break;

            case 2:
                globalVariables.setRows(20);
                setTexts(20);
                if (data != null)
                {
                    unlockExtreme(data);
                }
                setDifficulty();
                break;
        }
        _dropDown.value = globalVariables.getNumOfRows() - _MAPSIZEDIFFERENCE;
    }

    public void unlockExtreme(victoriesData data)
    {
        List<victoryType> victories = data.getVictories().FindAll(victory => victory.getSize() == globalVariables.getNumOfRows());
        //Debug.Log(victories.Count);
        bool extremeUnlock = true;
        for (int i = 0; i < victories.Count; ++i)
        {
            if (!victories[i].getIsWon())
            {
                extremeUnlock = false;
                break;
            }
        }
        if (extremeUnlock)
        {
            _extremeButton.enabled = true;
            _unlockImage.enabled = false;
            _extremeText.text = "EXTREMO\n" + getNumberOfBombs(_extremeMult).ToString() + " BOMBAS";
        }
        else
        {
            _extremeButton.enabled = false;
            _unlockImage.enabled = true;
        }
    }

    public int getNumberOfBombs(float mult)
    {
        return Mathf.RoundToInt((float)(mult * Mathf.Pow(globalVariables.getNumOfRows(), 2)));
    }

    public static int getMapSizeDifference()
    {
        return _MAPSIZEDIFFERENCE;
    }
    public void setDifficulty(int index)
    {
        switch (index)
        {
            case 0:
                _diffIndex = 0;
                globalVariables.setGameDifficulty(difficultyLevel.EASY);
                globalVariables.setBombsQuantity(getNumberOfBombs(_easyMult));
                _difficultyText.text = "FÁCIL";
                break;

            case 1:
                _diffIndex = 1;
                globalVariables.setGameDifficulty(difficultyLevel.MEDIUM);
                globalVariables.setBombsQuantity(getNumberOfBombs(_mediumMult));
                _difficultyText.text = "MEDIO";
                break;

            case 2:
                _diffIndex = 2;
                globalVariables.setGameDifficulty(difficultyLevel.HARD);
                globalVariables.setBombsQuantity(getNumberOfBombs(_hardMult));
                _difficultyText.text = "DIFÍCIL";
                break;
            case 3:
                _diffIndex = 3;
                globalVariables.setGameDifficulty(difficultyLevel.EXTREME);
                globalVariables.setBombsQuantity(getNumberOfBombs(_extremeMult));
                _difficultyText.text = "EXTREMO";
                break;
        }
    }
}
