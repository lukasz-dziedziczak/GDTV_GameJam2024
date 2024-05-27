using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Foreground : MonoBehaviour
{
    [SerializeField] Image image; 
    [SerializeField] Color black;
    [SerializeField] Color attacked;
    [SerializeField] float attackFadeTime;

    EMode mode;
    float modeChangeTime;
    float progressTime => Time.time - modeChangeTime;
    float attackedProgress => progressTime / attackFadeTime;

    public enum EMode
    {
        standBy,
        attacked,
        fadeIn,
        fadeOut
    }

    private void Update()
    {
        if (mode == EMode.attacked)
        {
            if (attackedProgress < 1) SetAlpha(Mathf.Lerp(1, 0, attackedProgress));
            else
            {
                SetAlpha(0);
                mode = EMode.standBy;
            }
        }
    }

    public void Attacked()
    {
        image.color = attacked;
        modeChangeTime = Time.time;
        mode = EMode.attacked;
    }

    private void SetAlpha(float alpha)
    {
        Color currentColor = image.color;
        currentColor.a = alpha;
        image.color = currentColor;
    }
}
