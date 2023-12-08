using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class gameSlotLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _mapSizeText;
    [SerializeField] private TextMeshProUGUI _difficultyText;
    [SerializeField] private TextMeshProUGUI _timeText;

    public TextMeshProUGUI getMapSizeText()
    {
        return _mapSizeText;
    }
    public TextMeshProUGUI getDifficultyText()
    {
        return _difficultyText;
    }
    public TextMeshProUGUI getTimeText()
    {
        return _timeText;
    }
}
