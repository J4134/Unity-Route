using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredLight : MonoBehaviour
{
    private int changeColorScoreStep;

    private int multiplier = 1;

    [SerializeField]
    private Color[] colors;

    private Light thisLight;

    [SerializeField]
    private Score score;

    private void Start()
    {
        thisLight = GetComponent<Light>();
        changeColorScoreStep = Random.Range(40, 60);  
    }

    private void Update()
    {
        if ((changeColorScoreStep * multiplier) > score.score)
            return;
        else
        {
            StartCoroutine(SmoothColor(colors[Random.Range(0, colors.Length)], 2f));
            multiplier++;
        }
        
    }

    private IEnumerator SmoothColor(Color endColor, float time)
    {

        float currentTime = 0f;
        do
        {
            thisLight.color = Color.Lerp(thisLight.color, endColor, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }
        while (currentTime <= time);
    }
}
