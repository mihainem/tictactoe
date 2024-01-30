using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


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


    public bool HasPlayerWon(int playerIndex, int[] cellsValues)
    {
        int cellsPerRow = 3;

        for (int i = 0; i < cellsPerRow; i++)
        {
            if (IsWinningLine(cellsValues[i], cellsValues[i + cellsPerRow], cellsValues[i + cellsPerRow * 2], playerIndex)
                || IsWinningLine(cellsValues[i * cellsPerRow], cellsValues[i * cellsPerRow + 1], cellsValues[i * cellsPerRow + 2], playerIndex)
                || IsWinningLine(cellsValues[0], cellsValues[4], cellsValues[8], playerIndex)
                || IsWinningLine(cellsValues[2], cellsValues[4], cellsValues[6], playerIndex)
                )
            {
                return true;
            }

        }


        return false;
    }

    protected bool IsWinningLine(int a, int b, int c, int playerIndex)
    {
        return a == playerIndex && a == b && b == c;
    }



    internal bool IsComplete(int[] cells)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i] == -1)
                return false;
        }
        return true;
    }

    public GameResult GetResult(int playerIndex, int[] cells = null)
    {

        if (HasPlayerWon(0, cells ?? cellsValues))
        {
            return GameResult.Win;
        }
        else if (HasPlayerWon(1, cells ?? cellsValues))
        {
            return GameResult.Lose;
        }
        else if (IsComplete(cells ?? cellsValues))
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