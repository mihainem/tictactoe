using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class GameManager : MonoBehaviour
{
    private GridChecker grid;
    [Inject] private UIManager ui;

    private int currentPlayerIndex = 0;

    private void Awake()
    {
        grid = new GridChecker();
    }

    public void PlayGame()
    {
        Debug.Log("Play");
        grid.ResetCellsValue();
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
                ui.ShowWin();
                break;
            case GameResult.Lose:
                ui.ShowLose();
                break;
            case GameResult.Tie:
                ui.ShowTie();
                break;
        }
    }
}

