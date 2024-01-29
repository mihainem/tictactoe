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

    internal void SetPlayButton(bool active)
    {
        playButton.SetActive(active);
    }

    internal void PrepareToShowScoreOnly()
    {
        SetPlayButton(false);
        result.text = "";
    }

    internal void ShowResult(string resultText)
    {
        SetPlayButton(true);
        result.text = resultText;
    }

    internal void UpdateScore(string scoreText)
    {
        score.text = scoreText;
    }
}
