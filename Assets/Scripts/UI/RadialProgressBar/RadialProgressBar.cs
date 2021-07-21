using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgressBar : MonoBehaviour
{
    [SerializeField]
    private Image fillImage;

    /// <summary>
    /// Sets the amount of progress.
    /// </summary>
    /// <param name="progressAmount">The percentage of progress. This should be between 0 to 1 inclusive</param>
    public void SetProgress(float progressAmount)
    {
        fillImage.fillAmount = progressAmount;
    }
}
