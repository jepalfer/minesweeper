using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class globalVariables : MonoBehaviour
{
    [SerializeField] private static int _numOfRows;
    [SerializeField] private static difficultyLevel _difficulty;
    [SerializeField] private TextMeshProUGUI _flags;
    [SerializeField] private static globalVariables _controller;
    [SerializeField] private static bool _timeTrial;
    private static float _musicTimePlayed;
    private static List<List<GameObject>> _tileGrid;
    private static int _bombsQuantity;

    private void Awake()
    {
        _controller = this;
    }

    public static globalVariables getController()
    {
        return _controller;
    }

    public static float getTimeMusicPlayed()
    {
        return _musicTimePlayed;
    }

    public TextMeshProUGUI getFlags()
    {
        return _flags;
    }

    public static bool getTimeTrial()
    {
        return _timeTrial;
    }

    public static void setRows(int row)
    {
        _numOfRows = row;
    }

    public static void setTimeMusicPlayed(float time)
    {
        _musicTimePlayed = time;
    }

    public static void setTimeTrial(bool value)
    {
        _timeTrial = value;
    }

    public static void setBombsQuantity(int quantity)
    {
        _bombsQuantity = quantity;
    }

    public static void setTileGrid(List<List<GameObject>> grid)
    {
        _tileGrid = grid;
    }

    public static void setGameDifficulty(difficultyLevel diff)
    {
        _difficulty = diff;
    }

    public static int getNumOfRows()
    {
        return _numOfRows;
    }
    public static difficultyLevel getDifficultyLevel()
    {
        return _difficulty;
    }
    public static List<List<GameObject>> getTileGrid()
    {
        return _tileGrid;
    }

    public static int getNumberOfBombs()
    {
        return _bombsQuantity;
    }
}
