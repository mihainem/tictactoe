using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ResultPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI result;
    [SerializeField] private TextMeshProUGUI score;

    internal void UpdateResult(string resultText)
    {
        result.text = resultText;
    }

    internal void UpdateScore(string scoreText)
    {
        score.text = scoreText;
    }
}
