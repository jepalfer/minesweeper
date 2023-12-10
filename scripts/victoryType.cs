using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class victoryType
{
    [SerializeField] private difficultyLevel _difficulty;
    [SerializeField] private int _size;
    [SerializeField] private bool _isWon;

    public victoryType(int size, difficultyLevel diff)
    {
        _size = size;
        _difficulty = diff;
        _isWon = false;
    }

    public difficultyLevel getDifficulty()
    {
        return _difficulty;
    }

    public int getSize()
    {
        return _size;
    }
    public bool getIsWon()
    {
        return _isWon;
    }

    public void setIsWon(bool value)
    {
        _isWon = value;
    }
}
