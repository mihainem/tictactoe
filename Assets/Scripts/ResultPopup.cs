using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class ResultPopup : Popup
{
    [SerializeField] private TextMeshProUGUI result;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private GameObject playButton;


    internal void UpdateResult(string resultText)
    {
        result.text = resultText;
    }

    internal void UpdateScore(string scoreText)
    {
        score.text = scoreText;
    }
}
