using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class game
{
    [SerializeField] private difficultyLevel _diff;
    [SerializeField] private int _mapSize;
    [SerializeField] private int _time;

    public game(difficultyLevel difficulty, int size, int time)
    {
        _diff = difficulty;
        _mapSize = size;
        _time = time;
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
}
