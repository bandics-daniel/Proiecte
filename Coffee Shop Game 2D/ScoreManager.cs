using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int finalScore = 30;

    public TextMeshProUGUI scoreText;
    public Slider progressBar;

    public TrophyPopup trophyPopup;         // Legătură cu scriptul trofeului
    private bool trophyShown = false;       // Pentru a evita reapariția

    public void AddPoints(int amount)
    {
        score += amount;
        UpdateUI();

        if (score >= finalScore && !trophyShown)
        {
            trophyPopup.ShowTrophy();
            trophyShown = true;
        }
    }

    public void SubtractPoints(int amount)
    {
        score -= amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Scor: " + score;

        if (progressBar != null)
            progressBar.value = score;
    }
}
