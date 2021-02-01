using Jaba.Route.UI;
using System.Collections;
using UnityEngine;

namespace Jaba.Route
{
    public class ColoredLight : MonoBehaviour
    {
        #region Variables

        [SerializeField]
        private Score score;

        [SerializeField]
        private Color[] colors;

        private Light thisLight;

        private int changeColorScoreStep;
        private int multiplier = 1;

        #endregion

        #region BuiltIn Methods

        private void Start()
        {
            thisLight = GetComponent<Light>();
            changeColorScoreStep = Random.Range(40, 60);
        }

        private void Update()
        {
            if (changeColorScoreStep * multiplier > score.score)
                return;
            else
            {
                StartCoroutine(SmoothColor(colors[Random.Range(0, colors.Length)], 2f));
                multiplier++;
            }
        }

        #endregion

        #region Custom Methods

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

        #endregion
    }
}