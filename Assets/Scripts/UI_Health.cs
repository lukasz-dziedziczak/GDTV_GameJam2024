using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image healthIndicator;
    [SerializeField] float lowHealthThreshold = 0.15f;
    [SerializeField] Color normalColor;
    [SerializeField] Color lowHealthColor;

    public void UpdateHealth()
    {
        healthIndicator.GetComponent<RectTransform>().localScale = new Vector3(player.Health.Percentage, 1, 1);

        if (player.Health.Percentage <= lowHealthThreshold)
        {
            healthIndicator.color = lowHealthColor;
        }
        else
        {
            healthIndicator.color = normalColor;
        }

    }

}
