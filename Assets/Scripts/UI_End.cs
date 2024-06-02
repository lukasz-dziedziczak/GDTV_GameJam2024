using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_End : MonoBehaviour
{
    [SerializeField] Button playAgainButton;
    [SerializeField] Button exitGameButton;
    [SerializeField] TMP_Text zombieKillCount;
    [SerializeField] TMP_Text time;

    private void OnEnable()
    {
        playAgainButton.onClick.AddListener(OnPlayAgainButtonPress);
        exitGameButton.onClick.AddListener(OnExitGameButtonPress);
        UpdateStats();
    }

    private void OnDisable()
    {
        playAgainButton.onClick.RemoveListener(OnPlayAgainButtonPress);
        playAgainButton.onClick.RemoveListener(OnExitGameButtonPress);
    }

    private void OnPlayAgainButtonPress()
    {
        Game.StartMatch();
    }

    private void OnExitGameButtonPress()
    {
        Application.Quit();
    }

    private void UpdateStats()
    {
        zombieKillCount.text = Game.Instance.KillCount.ToString();

        int mintues = Mathf.FloorToInt(Game.Instance.MatchLength / 60);
        int seconds = Mathf.FloorToInt(Game.Instance.MatchLength % 60);

        time.text = mintues.ToString("D2") + ":" + seconds.ToString("D2");
    }
}
