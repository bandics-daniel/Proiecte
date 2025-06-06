using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SpanishWordChecker : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI scoreText;
    public Slider progressBar;
    public ScoreManager scoreManager;
    public Button checkButton;

    public string correctWord = "taza";
    public int score = 0;
    private bool answeredCorrectly = false;


    IEnumerator ClearFeedback()
    {
        yield return new WaitForSeconds(4f);
        feedbackText.text = "";
    }
    public bool HasAnsweredCorrectly()
    {
        return answeredCorrectly;
    }



    public void CheckWord()
    {
        if (answeredCorrectly)
            return;

        if (inputField.text.ToLower() == correctWord)
        {
            feedbackText.text = "¡Correcto!";
            scoreManager.AddPoints(10);
            answeredCorrectly = true;

            inputField.interactable = false;
            checkButton.interactable = false;

            StartCoroutine(ClearFeedback());
        }
        else
        {
            feedbackText.text = "Pista: începe cu 't'";
            StartCoroutine(ClearFeedback());
        }
    }



}
