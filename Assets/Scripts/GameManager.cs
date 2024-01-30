using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class GameManager : MonoBehaviour
{
    [Inject] private UIManager ui;
    private GridChecker grid;
    private ScoreKeeper score;
    private APlayer[] players;


    private int currentPlayerIndex = 0;

    private void Awake()
    {
        grid = new GridChecker();
        score = new ScoreKeeper();
        players = new APlayer[] { new Player(grid, null), new Computer(grid, TapedCell) };
    }

    public void PlayGame()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        currentPlayerIndex = 0;
        grid.ResetCellsValue();
        ui.ResetCells();
        ui.SetResultPopupActive(false);
    }

    public void TapedCell(int cellIndex)
    {
        StopAllCoroutines();
        grid.PlaceMove(cellIndex, currentPlayerIndex);
        ui.PlaceSprite(cellIndex, currentPlayerIndex);
        StartCoroutine(TryShowResult());
    }

    private IEnumerator TryShowResult()
    {

        GameResult result = TryGetResult();
        if (result != GameResult.Playing)
        {
            yield return new WaitForSeconds(1);
            ShowResult(result);
        }
        else
        {
            SwitchPlayer();
            yield return new WaitForSeconds(1);
            TryPlayNextMove();
        }
    }

    void ShowResult(GameResult result)
    {
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
        ui.UpdateScore(score);
    }

    private void TryPlayNextMove()
    {
        players[currentPlayerIndex].PlayTurn();
    }

    private void SwitchPlayer()
    {
        players[currentPlayerIndex].OnExitState();
        currentPlayerIndex = (currentPlayerIndex + 1) % 2;
        players[currentPlayerIndex].OnEnterState();
    }

    private GameResult TryGetResult()
    {
        GameResult result = grid.GetResult(currentPlayerIndex);

        return result;
    }

    internal void QuitGame()
    {
        Application.Quit();
    }

}

