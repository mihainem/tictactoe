using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ActionToTapCell(int cellIndex);
public abstract class APlayer
{
    internal ActionToTapCell TapCell;
    protected GridChecker grid;

    public APlayer(GridChecker grid, ActionToTapCell actionToTapCell)
    {
        TapCell = actionToTapCell;
        this.grid = grid;
    }
    internal virtual void OnEnterState() { }
    internal virtual void OnExitState() { }
    internal virtual void PlayTurn() { }
}
