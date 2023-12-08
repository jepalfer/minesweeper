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
    private int _diffIndex = 0;
    private float _easyMult = 0.1f;
    private float _mediumMult = 0.2f;
    private float _hardMult = 0.27f;
    private float _extremeMult = 0.35f;

    private void Start()
    {
        globalVariables.setGameDifficulty(difficultyLevel.EASY);
        globalVariables.setRows(7);
        globalVariables.setBombsQuantity(getNumberOfBombs(_easyMult));
        _easyText.text = "FÁCIL\n" + getNumberOfBombs(_easyMult).ToString() + " BOMBAS";
        _mediumText.text = "MEDIO\n" + getNumberOfBombs(_mediumMult).ToString() + " BOMBAS";
        _hardText.text = "DIFÍCIL\n" + getNumberOfBombs(_hardMult).ToString() + " BOMBAS";

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
        }
    }
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void setDefaultMap(int index)
    {
        victoriesData data = saveSystem.loadVictories();
        switch (index)
        {
            case 0:
                globalVariables.setRows(7);
                _levelText.text = "7x7";
                _easyText.text = "FÁCIL\n" + getNumberOfBombs(_easyMult).ToString() + " BOMBAS";
                _mediumText.text = "MEDIO\n" + getNumberOfBombs(_mediumMult).ToString() + " BOMBAS";
                _hardText.text = "DIFÍCIL\n" + getNumberOfBombs(_hardMult).ToString() + " BOMBAS";

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
                }
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
                break;

            case 1:
                globalVariables.setRows(15);
                _levelText.text = "15x15";
                _easyText.text = "FÁCIL\n" + getNumberOfBombs(_easyMult).ToString() + " BOMBAS";
                _mediumText.text = "MEDIO\n" + getNumberOfBombs(_mediumMult).ToString() + " BOMBAS";
                _hardText.text = "DIFÍCIL\n" + getNumberOfBombs(_hardMult).ToString() + " BOMBAS";
                if (data != null)
                {
                    bool extremeUnlock = true;
                    for (int i = 0; i < 3; i++)
                    {
                        if (data.get15x15Victories()[i] == 0)
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
                break;

            case 2:
                globalVariables.setRows(20);
                _levelText.text = "20x20";
                _easyText.text = "FÁCIL\n" + getNumberOfBombs(_easyMult).ToString() + " BOMBAS";
                _mediumText.text = "MEDIO\n" + getNumberOfBombs(_mediumMult).ToString() + " BOMBAS";
                _hardText.text = "DIFÍCIL\n" + getNumberOfBombs(_hardMult).ToString() + " BOMBAS";
                if (data != null)
                {
                    bool extremeUnlock = true;
                    for (int i = 0; i < 3; i++)
                    {
                        if (data.get20x20Victories()[i] == 0)
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
                break;
        }
    }

    public int getNumberOfBombs(float mult)
    {
        return Mathf.RoundToInt((float)(mult * Mathf.Pow(globalVariables.getNumOfRows(), 2)));
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
