using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class victoriesData
{
    [SerializeField] private int[] _7x7Victories;
    [SerializeField] private int[] _15x15Victories;
    [SerializeField] private int[] _20x20Victories;

    public victoriesData()
    {
        _7x7Victories = new int[3];
        _15x15Victories = new int[3];
        _20x20Victories = new int[3];
    }

    public victoriesData(int [] victories7x7, int[] victories15x15, int[] victories20x20)
    {
        _7x7Victories = victories7x7;
        _15x15Victories = victories15x15;
        _20x20Victories = victories20x20;
    }

    public victoriesData(int mapSize, difficultyLevel difficulty)
    {
        wonGame(difficulty, mapSize);
    }

    public int[] get7x7Victories()
    {
        return _7x7Victories;
    }
    public int[] get15x15Victories()
    {
        return _15x15Victories;
    }
    public int[] get20x20Victories()
    {
        return _20x20Victories;
    }

    public void wonGame(difficultyLevel difficulty, int mapSize)
    {
        if (mapSize == 7)
        {
            if (difficulty == difficultyLevel.EASY)
            {
                _7x7Victories[0] = 1;
            }
            else if (difficulty == difficultyLevel.MEDIUM)
            {
                _7x7Victories[1] = 1;
            }
            else
            {
                _7x7Victories[2] = 1;
            }
        }
        else if (mapSize == 15)
        {
            if (difficulty == difficultyLevel.EASY)
            {
                _15x15Victories[0] = 1;
            }
            else if (difficulty == difficultyLevel.MEDIUM)
            {
                _15x15Victories[1] = 1;
            }
            else
            {
                _15x15Victories[2] = 1;
            }
        }
        else
        {
            if (difficulty == difficultyLevel.EASY)
            {
                _20x20Victories[0] = 1;
            }
            else if (difficulty == difficultyLevel.MEDIUM)
            {
                _20x20Victories[1] = 1;
            }
            else
            {
                _20x20Victories[2] = 1;
            }
        }
    }
}
