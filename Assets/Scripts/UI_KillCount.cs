using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_KillCount : MonoBehaviour
{
    [SerializeField] TMP_Text killCount;

    private void Start()
    {
        UpdateKillCount();
    }

    public void UpdateKillCount()
    {
        killCount.text = Game.Instance.KillCount.ToString();
    }
}
