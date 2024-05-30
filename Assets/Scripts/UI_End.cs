using UnityEngine;
using UnityEngine.UI;

public class UI_End : MonoBehaviour
{
    [SerializeField] Button playAgainButton;

    private void OnEnable()
    {
        playAgainButton.onClick.AddListener(OnPlayAgainButtonPress);
    }

    private void OnDisable()
    {
        playAgainButton.onClick.RemoveListener(OnPlayAgainButtonPress);
    }

    private void OnPlayAgainButtonPress()
    {
        Game.StartMatch();
    }
}
