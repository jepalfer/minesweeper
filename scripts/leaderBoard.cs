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
    [SerializeField] private GameObject _timeImage;
    [SerializeField] private bool _descendentTime = false;
    [SerializeField] private bool _isTimeTrial;
    List<game> gameHistory;
    List<game> sortedHistory;
    List<GameObject> prefabArray;
    private void Start()
    {
        prefabArray = new List<GameObject>();
        leaderboardData data = saveSystem.loadLeaderBoard();
        if (data != null)
        {
            sortGamesByTime();
            createLeaderBoard();
        }
    }

    public void invertTime()
    {
        _descendentTime = !_descendentTime;
        if (_descendentTime)
        {
            _timeImage.transform.rotation = new Quaternion(0, 0, 0, 0);
            destroyGames();
            sortGamesByTime();
            createLeaderBoard();
        }
        else
        {
            _timeImage.transform.rotation = new Quaternion(0, 0, 180, 0);
            destroyGames();
            sortGamesByTime();
            createLeaderBoard();
        }
    }

    public void sortGamesByTime()
    {
        sortedHistory = new List<game>();
        gameHistory = saveSystem.loadLeaderBoard().getGamesPlayed().FindAll(game => game.getIsTimeTrial() == _isTimeTrial);

        if (_descendentTime)
        {
            while (gameHistory.Count > 0)
            {
                int minIndex = 0;
                int minimum = gameHistory[0].getTime();
                for (int i = 0; i < gameHistory.Count; ++i)
                {
                    if (gameHistory[i].getTime() > minimum)
                    {
                        minimum = gameHistory[i].getTime();
                        minIndex = i;
                    }
                }
                sortedHistory.Add(gameHistory[minIndex]);
                gameHistory.RemoveAt(minIndex);
            }
        }
        else
        {
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
        }
    }
    
    public void createLeaderBoard()
    {
        int hours = 0, minutes = 0, seconds = 0;
        for (int i = 0; i < sortedHistory.Count; ++i)
        {
            hours = minutes = seconds = 0;
            GameObject win = Instantiate(_gamePrefab);
            prefabArray.Add(win);
            win.GetComponent<gameSlotLogic>().getMapSizeText().text = sortedHistory[i].getMapSize().ToString() + "x" + sortedHistory[i].getMapSize().ToString();
            win.GetComponent<gameSlotLogic>().getDifficultyText().text = sortedHistory[i].getDifficulty().ToString();

            seconds = sortedHistory[i].getTime();
            if (seconds >= 60)
            {
                minutes = seconds / 60;
                seconds = seconds % 60;
            }
            if (minutes >= 60)
            {
                hours = minutes / 60;
                minutes = minutes % 60;
            }

            win.GetComponent<gameSlotLogic>().getTimeText().text = hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();

            win.transform.SetParent(_gameHolder);
        }
    }

    public void destroyGames()
    {
        for (int i = 0; i < prefabArray.Count; ++i)
        {
            Destroy(prefabArray[i]);
        }
        prefabArray.Clear();
        sortedHistory.Clear();
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
