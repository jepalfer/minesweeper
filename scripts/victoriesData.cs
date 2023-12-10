using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class victoriesData
{

    [SerializeField] private List<victoryType> _victories;

    public victoriesData()
    {
        _victories = new List<victoryType>();

        for (int i = 0; i <= 20; ++i)
        {
            victoryType easy = new victoryType(i + levelSelectLogic.getMapSizeDifference(), difficultyLevel.EASY);
            victoryType medium = new victoryType(i + levelSelectLogic.getMapSizeDifference(), difficultyLevel.MEDIUM);
            victoryType hard = new victoryType(i + levelSelectLogic.getMapSizeDifference(), difficultyLevel.HARD);

            _victories.Add(easy);
            _victories.Add(medium);
            _victories.Add(hard);
        }
    }

    public victoriesData(List<victoryType> victories)
    {
        _victories = victories;
    }


    public List<victoryType> getVictories()
    {
        return _victories;
    }

    
    public void wonGame(difficultyLevel difficulty, int mapSize)
    {
        _victories.Find(victory => victory.getDifficulty() == difficulty && victory.getSize() == mapSize).setIsWon(true);
    }
}
