using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class GameManager : MonoBehaviour
{
    [Inject] private UIManager ui;
    private GridChecker grid;
    private ScoreKeeper score;


    private int currentPlayerIndex = 0;

    private void Awake()
    {
        grid = new GridChecker();
        score = new ScoreKeeper();
    }

    public void PlayGame()
    {
        Debug.Log("Play");
        ResetGame();
    }

    public void ResetGame()
    {
        currentPlayerIndex = 0;
        grid.ResetCellsValue();
        ui.ResetCells();
        ui.SetResultPopup(false);
    }

    public void TapedCell(Button cellImage, int cellIndex)
    {
        grid.PlaceMove(cellIndex, currentPlayerIndex);
        ui.PlaceSprite(cellImage, currentPlayerIndex);
        TryShowResult();
        SwitchPlayer();
    }

    private void SwitchPlayer()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % 2;
    }

    private void TryShowResult()
    {
        GameResult result = grid.GetResult(currentPlayerIndex);
        switch (result)
        {
            case GameResult.Win:
                score.IncreaseWins();
                ui.ShowWin();
                break;
            case GameResult.Lose:
                score.IncreaseLoses();
                ui.ShowLose();
                break;
            case GameResult.Tie:
                score.IncreaseTies();
                ui.ShowTie();
                break;
        }
        if (result != GameResult.Playing)
        {
            ui.UpdateScore(score);
            ui.SetResultPopup(true);
        }
    }

    internal void QuitGame()
    {
        Application.Quit();
    }

}

