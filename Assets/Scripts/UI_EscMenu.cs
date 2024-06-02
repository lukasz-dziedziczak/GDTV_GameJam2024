using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EscMenu : MonoBehaviour
{
    [SerializeField] UI ui;
    [SerializeField] Button unpauseButton;
    [SerializeField] Button resetButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button exitButton;

    private void OnEnable()
    {
        unpauseButton.onClick.AddListener(OnUnpauseButtonPress);
        resetButton.onClick.AddListener(OnResetButtonPress);
        mainMenuButton.onClick.AddListener(OnMainMenuButtonPress);
        exitButton.onClick.AddListener(OnExitButtonPress);

        Time.timeScale = 0;
        Game.LockCursor(false);
    }

    private void OnDisable()
    {
        unpauseButton.onClick.RemoveListener(OnUnpauseButtonPress);
        resetButton.onClick.RemoveListener(OnResetButtonPress);
        mainMenuButton.onClick.RemoveListener(OnMainMenuButtonPress);
        exitButton.onClick.RemoveListener(OnExitButtonPress);
    }

    public void OnUnpauseButtonPress()
    {
        ui.HidePauseMenu();
    }

    private void OnResetButtonPress()
    {
        Time.timeScale = 1;

        Game.ResetRound();
    }

    private void OnMainMenuButtonPress()
    {
        Time.timeScale = 1;

        Game.ReturnToMenu();
    }

    private void OnExitButtonPress()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
