using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Start : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] RectTransform title0;
    [SerializeField] RectTransform title1;
    [SerializeField] RectTransform title2;
    [SerializeField] float showLength;
    float showStart;
    float showDuration => Time.time - showStart;
    float showProgress => showDuration / showLength;
    RectTransform buttonRectTrans;
    int titleIndex;

    private void Awake()
    {
        buttonRectTrans = startButton.GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        startButton.onClick.AddListener(OnStartButtonPress);

        titleIndex = 0;
        ShowScale(0, 0);
        ShowScale(1, 0);
        ShowScale(2, 0);
        ShowScale(3, 0);
        showStart = Time.time;
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartButtonPress);
    }

    private void OnStartButtonPress()
    {
        Game.StartMatch();
    }

    private void Update()
    {
        if (titleIndex < 4)
        {
            float scale = 0;
            if (showProgress < 1)
            {
                scale = Mathf.Lerp(0, 1, showProgress);
                ShowScale(titleIndex, scale);
            }
            else
            {
                ShowScale(titleIndex, 1);
                titleIndex++;
                showStart = Time.time;
            }
        }
    }

    private void ShowScale(int title, float scale)
    {
        switch (title)
        {
            case 0:
                title0.localScale = new Vector3(scale, scale, scale);
                break;

            case 1:
                title1.localScale = new Vector3(scale, scale, scale);
                break;

            case 2:
                title2.localScale = new Vector3(scale, scale, scale);
                break;

            case 3:
                buttonRectTrans.localScale = new Vector3(scale, scale, scale);
                break;
        }
        
    }
}
