using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject start;
    [SerializeField] GameObject game;
    [SerializeField] GameObject end;
    [SerializeField] GameObject pauseMenu;

    private void Start()
    {
        

    }

    public void SwitchToGame()
    {
        start.gameObject.SetActive(false);
        game.gameObject.SetActive(true);
        end.gameObject.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void SwitchToStart()
    {
        start.gameObject.SetActive(true);
        game.gameObject.SetActive(false);
        end.gameObject.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void SwitchToEnd()
    {
        start.gameObject.SetActive(false);
        game.gameObject.SetActive(false);
        end.gameObject.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        game.gameObject.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
        game.gameObject.SetActive(true);
        Time.timeScale = 1;
        Game.LockCursor(true);
    }

    public bool PauseMenuShowing => pauseMenu.activeSelf;
}
