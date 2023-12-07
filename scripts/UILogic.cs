using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILogic : MonoBehaviour
{
    private int _time;
    [SerializeField] private TextMeshProUGUI _timerUI;

    private void Start()
    {
        _time = 0;
        _timerUI.color = Color.blue;
        _timerUI.text = _time.ToString();
        InvokeRepeating("timePass", 0, 1);
    }

    public void timePass()
    {
        _time++;
        _timerUI.text = _time.ToString();
    }
}
