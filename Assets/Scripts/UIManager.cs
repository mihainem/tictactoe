using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Sprite xSprite;
    [SerializeField] private Sprite oSprite;

    internal Button[] GetGridCells()
    {
        throw new NotImplementedException();
    }

    internal void PlaceSprite(Button cell, int currentPlayerIndex)
    {
        cell.interactable = false;
        cell.image.sprite = currentPlayerIndex == 0 ? xSprite : oSprite;
        cell.image.color = Color.white;
    }

    internal void ShowLose()
    {
        Debug.Log("Player Loses");
    }

    internal void ShowTie()
    {
        Debug.Log("It's a Tie");
    }

    internal void ShowWin()
    {
        Debug.Log("Player Wins");
    }
}
