using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour {
    [SerializeField] private Color[] colors;
    [SerializeField] private Image background;

    private int colorIndex = 0;

    private Color currentColor;

    private void Start()
    {
        NextBackground();
    }

    public void NextBackground()
    {
        Debug.Log("NXT_BCK");
        currentColor = background.color;

        if (colorIndex > colors.Length - 1)
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
        background.color = Color.Lerp(currentColor, colors[colorIndex], Time.deltaTime*10);
    }
}
