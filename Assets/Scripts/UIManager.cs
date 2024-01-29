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
    [SerializeField] private ResultPopup resultPopup;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Transform grid;

    private Button[] cellButtons;

    private void Awake()
    {
        cellButtons = grid.GetComponentsInChildren<Button>();
    }

    internal void PlaceSprite(Button cell, int currentPlayerIndex)
    {
        cell.interactable = false;
        cell.image.sprite = currentPlayerIndex == 0 ? xSprite : oSprite;
        cell.image.color = Color.white;
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

    internal void ShowLose()
    {
        Debug.Log("Player Loses");
        resultPopup.UpdateResult("You lost!");
    }

    internal void ShowTie()
    {
        Debug.Log("It's a Tie");
        resultPopup.UpdateResult("It's a Tie!");
    }

    public void SetResultPopup(bool active)
    {
        resultPopup.gameObject.SetActive(active);
    }

    internal void ShowWin()
    {
        Debug.Log("Player Wins");
        resultPopup.UpdateResult("You Win!");
    }

    internal void UpdateScore(ScoreKeeper scoreKeeper)
    {
        string scoreString = scoreKeeper.ToString();
        score.text = scoreString;
        resultPopup.UpdateScore(scoreString);
    }
}
