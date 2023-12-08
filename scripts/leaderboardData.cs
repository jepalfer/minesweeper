using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class leaderboardData
{
    [SerializeField] private List<game> _gamesPlayed;

    public leaderboardData()
    {
        _gamesPlayed = new List<game>();
    }

    public leaderboardData(List<game> games)
    {
        _gamesPlayed = games;
    }

    public void wonGame(game GameWon)
    {
        _gamesPlayed.Add(GameWon);
    }

    public List<game> getGamesPlayed()
    {
        return _gamesPlayed;
    }
}
