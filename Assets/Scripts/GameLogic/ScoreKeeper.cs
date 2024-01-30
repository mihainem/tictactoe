using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper
{
    public int total;
    public int wins;
    public int loses;
    public int ties;
    public int streak;

    public ScoreKeeper()
    {
        total = 0;
        wins = 0;
        loses = 0;
        ties = 0;
        streak = 0;
    }

    public void IncreaseWins()
    {
        wins += 1;
        streak += 1;
    }

    public void IncreaseLoses()
    {
        loses += 1;
        streak = 0;
    }

    public void IncreaseTies()
    {
        ties += 1;
    }

    public override string ToString()
    {
        return $"Total: {wins + loses + ties}, Wins: {wins}, Loses: {loses}, Streak: {streak}";
    }
}
