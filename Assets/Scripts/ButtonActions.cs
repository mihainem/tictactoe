using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonActions : MonoBehaviour
{
    [Inject] private GameManager gameManager;
    [Inject] private UIManager ui;
    private int childIndex;

    private void Awake()
    {
        childIndex = transform.GetSiblingIndex();
    }

    public void TappedCell()
    {
        gameManager.TapedCell(childIndex);
    }

    public void TappedPlay()
    {
        gameManager.PlayGame();
    }

    public void TappedQuit()
    {
        gameManager.QuitGame();
    }

    public void TappedScoreButton()
    {
        ui.ShowScore();
    }

    public void TappedSettingsButton()
    {
        ui.ShowSettings();
    }

}
