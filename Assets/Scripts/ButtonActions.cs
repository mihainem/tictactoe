using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonActions : MonoBehaviour
{
    [Inject] private GameManager gameManager;
    [Inject] private UIManager ui;
    private Button cellButton;
    private int childIndex;

    private void Awake()
    {
        cellButton = GetComponent<Button>();
        childIndex = transform.GetSiblingIndex();
    }

    public void TappedCell()
    {
        gameManager.TapedCell(cellButton, childIndex);
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
