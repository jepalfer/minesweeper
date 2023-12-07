using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelectLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _easyText;
    [SerializeField] private TextMeshProUGUI _mediumText;
    [SerializeField] private TextMeshProUGUI _hardText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _difficultyText;
    private int _diffIndex = 0;
    private float _easyMult = 0.1f;
    private float _mediumMult = 0.2f;
    private float _hardMult = 0.35f;

    private void Start()
    {
        globalVariables.setGameDifficulty(difficultyLevel.EASY);
        globalVariables.setRows(7);
        globalVariables.setBombsQuantity(getNumberOfBombs(_easyMult));
        _easyText.text = "FÁCIL\n" + getNumberOfBombs(_easyMult).ToString() + " BOMBAS";
        _mediumText.text = "MEDIO\n" + getNumberOfBombs(_mediumMult).ToString() + " BOMBAS";
        _hardText.text = "DIFÍCIL\n" + getNumberOfBombs(_hardMult).ToString() + " BOMBAS";
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
        switch (index)
        {
            case 0:
                globalVariables.setRows(7);
                _levelText.text = "7x7";
                _easyText.text = "FÁCIL\n" + getNumberOfBombs(_easyMult).ToString() + " BOMBAS";
                _mediumText.text = "MEDIO\n" + getNumberOfBombs(_mediumMult).ToString() + " BOMBAS";
                _hardText.text = "DIFÍCIL\n" + getNumberOfBombs(_hardMult).ToString() + " BOMBAS";

                if (_diffIndex == 0)
                {
                    globalVariables.setBombsQuantity(getNumberOfBombs(_easyMult));
                }
                else if (_diffIndex == 1)
                {
                    globalVariables.setBombsQuantity(getNumberOfBombs(_mediumMult));
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
                if (_diffIndex == 0)
                {
                    globalVariables.setBombsQuantity(getNumberOfBombs(_easyMult));
                }
                else if (_diffIndex == 1)
                {
                    globalVariables.setBombsQuantity(getNumberOfBombs(_mediumMult));
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
                if (_diffIndex == 0)
                {
                    globalVariables.setBombsQuantity(getNumberOfBombs(_easyMult));
                }
                else if (_diffIndex == 1)
                {
                    globalVariables.setBombsQuantity(getNumberOfBombs(_mediumMult));
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
        }
    }
}
