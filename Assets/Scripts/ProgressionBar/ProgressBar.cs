using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    public Slider progressSlider;
    private float timeRemaning;
    private const float timeMax = 250f;
    private void Start()
    {
        timeRemaning = 0.07f;
    }

    private void Update()
    {
        progressSlider.value = CalculateSliderValue();

        timeRemaning += Time.deltaTime;

        if (timeRemaning >= timeMax)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private float CalculateSliderValue()
    {
        return (timeRemaning / timeMax);
    }
    
    public void BarraAtt(float value)
    {
        timeRemaning += value;

        if (timeRemaning > timeMax)
        {
            timeRemaning = timeMax;
        }

        if (timeRemaning < 0)
        {
            timeRemaning = 0;
        }
    }
}
