using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScorePopup : Popup
{
    [SerializeField] private TextMeshProUGUI score;

    internal void SetScoreText(string text)
    {
        score.text = text;
    }
}
