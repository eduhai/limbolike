using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    public PlayerPointsInfo score;

    public Text pointsText;

    private void Update()
    {
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        pointsText.text = "Points: " + score.value.ToString();
    }
}
