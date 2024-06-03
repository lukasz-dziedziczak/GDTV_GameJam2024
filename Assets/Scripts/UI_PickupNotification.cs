using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PickupNotification : MonoBehaviour
{
    RectTransform rectTransform;
    TMP_Text text;

    [SerializeField] float showLength;
    float showStart;
    float showDuration => Time.time - showStart;
    float showProgress => showDuration / showLength;
    bool showing;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        text = GetComponent<TMP_Text>();
    }

    public void Show(string notification)
    {
        text.text = notification;
        showStart = Time.time;
        showing = true;
    }

    private void Update()
    {
        if (showing)
        {
            float scale = 0;
            if (showProgress >= 1)
            {
                scale = 0;
                showing = false;
            }
            else if(showProgress < 0.25)
            {
                scale = Mathf.Lerp(0, 1, showProgress * 4);
            }
            else if (showProgress >= 0.25 && showProgress < 0.75)
            {
                scale = 1;
            }
            else if (showProgress >= 0.75)
            {
                scale = Mathf.Lerp(1, 0, (showProgress - 0.75f) * 4 );
            }


            ShowScale(scale);
            
        }
    }

    private void ShowScale(float scale)
    {
        rectTransform.localScale = new Vector3(scale, scale , scale);
    }
}
