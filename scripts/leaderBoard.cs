using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class leaderBoard : MonoBehaviour
{
    [SerializeField] private Transform _gameHolder;
    [SerializeField] private GameObject _gamePrefab;
    private void Start()
    {
        leaderboardData data = saveSystem.loadLeaderBoard();
        List<game> gameHistory;
        List<game> sortedHistory = new List<game>();
        if (data != null)
        {
            gameHistory = saveSystem.loadLeaderBoard().getGamesPlayed();
            while (gameHistory.Count > 0)
            {
                int minIndex = 0;
                int minimum = gameHistory[0].getTime();
                for (int i = 0; i < gameHistory.Count; ++i)
                {
                    if (gameHistory[i].getTime() < minimum)
                    {
                        minimum = gameHistory[i].getTime();
                        minIndex = i;
                    }
                }
                sortedHistory.Add(gameHistory[minIndex]);
                gameHistory.RemoveAt(minIndex);
            }
            for (int i = 0; i < sortedHistory.Count; ++i)
            {
                GameObject win = Instantiate(_gamePrefab);
                win.GetComponent<gameSlotLogic>().getMapSizeText().text = sortedHistory[i].getMapSize().ToString() + "x" + sortedHistory[i].getMapSize().ToString();
                win.GetComponent<gameSlotLogic>().getDifficultyText().text = sortedHistory[i].getDifficulty().ToString();
                win.GetComponent<gameSlotLogic>().getTimeText().text = sortedHistory[i].getTime().ToString() + "s";

                win.transform.SetParent(_gameHolder);
            }
        }
    }

    public Transform getGameHolder()
    {
        return _gameHolder;
    }

    public GameObject getGamePrefab()
    {
        return _gamePrefab;
    }
}
