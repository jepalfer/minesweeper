using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menuLogic : MonoBehaviour
{
    [SerializeField] private GameObject _leaderBoardPanel;
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void back()
    {
        _leaderBoardPanel.SetActive(false);
    }
    public void showLeaderBoard()
    {
        _leaderBoardPanel.SetActive(true);
    }
}
