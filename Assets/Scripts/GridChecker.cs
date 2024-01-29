using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


/// <summary>
/// GridCheckerClass encapsulates all actions on grid and its cells, including checking for valid matches.
/// </summary>
public class GridChecker
{
    public int[] cellsValues;

    public GridChecker()
    {
        cellsValues = new int[9];
        ResetCellsValue();
    }

    internal void ResetCellsValue()
    {
        int length = cellsValues.Length;
        for (int i = 0; i < length; i++)
        {
            cellsValues[i] = -1;
        }
    }

    public bool IsWinningCombination(int[] cellsValues)
    {
        int cellsPerRow = 3;

        for (int i = 0; i < cellsPerRow; i++)
        {
            if (IsCombinationValid(cellsValues[i], cellsValues[i + cellsPerRow], cellsValues[i + cellsPerRow * 2])
                || IsCombinationValid(cellsValues[i * cellsPerRow], cellsValues[i * cellsPerRow + 1], cellsValues[i * cellsPerRow + 2])
                || IsCombinationValid(cellsValues[0], cellsValues[4], cellsValues[8])
                || IsCombinationValid(cellsValues[2], cellsValues[4], cellsValues[6])
                )
            {
                return true;
            }

        }


        return false;
    }


    private bool HasWinningCombination()
    {
        return IsWinningCombination(cellsValues);
    }

    protected bool IsCombinationValid(int a, int b, int c)
    {
        return a != -1 && a == b && b == c;
    }



    internal bool IsComplete()
    {
        for (int i = 0; i < cellsValues.Length; i++)
        {
            if (cellsValues[i] == -1)
                return false;
        }
        return true;
    }

    internal GameResult GetResult(int playerIndex)
    {
        if (HasWinningCombination() && playerIndex == 0)
        {
            return GameResult.Win;
        }
        else if (HasWinningCombination() && playerIndex == 1)
        {
            return GameResult.Lose;
        }
        else if (IsComplete())
        {
            return GameResult.Tie;
        }
        else
        {
            return GameResult.Playing;
        }
    }


    internal int CountTappedCells()
    {
        int countTappedCells = 0;
        for (int i = 0; i < cellsValues.Length; i++)
        {
            if (cellsValues[i] != -1)
                countTappedCells++;
        }

        return countTappedCells;
    }

    internal bool HasTappedCells()
    {
        return CountTappedCells() > 0;
    }

    internal void PlaceMove(int cellIndex, int currentPlayerIndex)
    {
        cellsValues[cellIndex] = currentPlayerIndex;
    }
}