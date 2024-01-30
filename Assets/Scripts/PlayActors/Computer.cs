using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : APlayer
{
    public Computer(GridChecker grid, ActionToTapCell actionToTapCell) : base(grid, actionToTapCell) { }

    internal override void PlayTurn()
    {
        //return index of an empty cell (where cellValue == -1)
        int index = Random.Range(0, grid.cellsValues.Length);
        while (grid.cellsValues[index] != -1)
        {
            index = Random.Range(0, grid.cellsValues.Length);
        }

        TapCell?.Invoke(index);
    }
}
