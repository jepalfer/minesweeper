using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class game
{
    [SerializeField] private difficultyLevel _diff;
    [SerializeField] private bool _isTimeTrial;
    [SerializeField] private int _mapSize;
    [SerializeField] private int _time;

    public game(difficultyLevel difficulty, int size, int time, bool timeTrial)
    {
        _diff = difficulty;
        _mapSize = size;
        _time = time;
        _isTimeTrial = timeTrial;
    }

    public difficultyLevel getDifficulty()
    {
        return _diff;
    }

    public int getMapSize()
    {
        return _mapSize;
    }
    public int getTime()
    {
        return _time;
    }

    public bool getIsTimeTrial()
    {
        return _isTimeTrial;
    }
}
