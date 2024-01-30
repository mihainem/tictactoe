using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Sprite xSprite;
    [SerializeField] private Sprite oSprite;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Transform grid;

    [Header("Popups")]
    [SerializeField] private ResultPopup resultPopup;
    [SerializeField] private SettingsPopup settingsPopup;
    [SerializeField] private ScorePopup scorePopup;

    private Button[] cellButtons;

    private void Awake()
    {
        cellButtons = grid.GetComponentsInChildren<Button>();
    }

    internal void PlaceSprite(int cellIndex, int currentPlayerIndex)
    {
        cellButtons[cellIndex].interactable = false;
        cellButtons[cellIndex].image.sprite = currentPlayerIndex == 0 ? xSprite : oSprite;
        cellButtons[cellIndex].image.color = Color.white;
    }

    internal void ResetCells()
    {
        int length = cellButtons.Length;
        for (int i = 0; i < length; i++)
        {
            cellButtons[i].interactable = true;
            cellButtons[i].image.color = Color.black;
            cellButtons[i].image.sprite = null;
        }
    }

    internal void ShowWin()
    {
        Debug.Log("Player Won!");
        resultPopup.UpdateResult("You Win!");
        SetResultPopupActive(true);
    }

    internal void ShowLose()
    {
        Debug.Log("Player Lost!");
        resultPopup.UpdateResult("You lost!");
        SetResultPopupActive(true);
    }

    internal void ShowTie()
    {
        Debug.Log("It's a Tie");
        resultPopup.UpdateResult("It's a Tie!");
        SetResultPopupActive(true);
    }

    public void SetResultPopupActive(bool active)
    {
        resultPopup.gameObject.SetActive(active);
    }

    public void SetScorePopupActive(bool active)
    {
        scorePopup.gameObject.SetActive(active);
    }


    internal void UpdateScore(ScoreKeeper scoreKeeper)
    {
        string scoreString = scoreKeeper.ToString();
        score.text = scoreString;
        resultPopup.UpdateScore(scoreString);
        scorePopup.SetScoreText(scoreString);
    }

    internal void ShowSettings()
    {
        settingsPopup.gameObject.SetActive(true);
    }

    internal void ShowScore()
    {
        SetScorePopupActive(true);
    }
}
