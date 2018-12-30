using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour {
    [SerializeField] private Color[] colors;
    [SerializeField] private Image background;
    [SerializeField] private int speed;

    private int colorIndex = 0;

    float timeLeft;
    Color targetColor;

    private void Start()
    {
        NextBackground();
    }



    public void NextBackground()
    {
        if (colorIndex >= colors.Length - 1)
        {
            colorIndex = 0;
        }
        else
        {
            colorIndex++;
        }
    }

    private void Update()
    {
        if (timeLeft <= Time.deltaTime)
        {
            background.color = targetColor;
            targetColor = colors[colorIndex];
            timeLeft = 1.0f;
        }
        else
        {
            background.color = Color.Lerp(background.color, targetColor, Time.deltaTime / (timeLeft*speed));
            timeLeft -= Time.deltaTime;
        }
    }
}
