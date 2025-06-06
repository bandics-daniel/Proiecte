using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BaristaDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI questionText;
    public Button[] answerButtons;
    public TextMeshProUGUI feedbackText;
    public ScoreManager scoreManager;

    private bool answered = false;

    void OnMouseDown()
    {
        if (!answered && dialoguePanel != null)
        {
            dialoguePanel.SetActive(true);
            questionText.text = "¿Qué deseas?";
        }
    }

    public void ChooseAnswer(int index)
    {
        if (answered) return;

        if (index == 0) // răspuns corect
        {
            feedbackText.text = "¡Muy bien!";
            scoreManager.AddPoints(20);
            answered = true;

            // Dezactivează panelul după o mică întârziere ca să vezi feedback-ul
            StartCoroutine(ClosePanelDelayed());

            // Dezactivează toate butoanele
            foreach (Button btn in answerButtons)
            {
                btn.interactable = false;
            }
        }
        else
        {
            feedbackText.text = "Incorrecto. Încearcă din nou!";
            scoreManager.SubtractPoints(5);
            StartCoroutine(ClearFeedback());
        }
    }

    private IEnumerator ClearFeedback()
    {
        yield return new WaitForSeconds(4f);
        feedbackText.text = "";
    }

    private IEnumerator ClosePanelDelayed()
    {
        yield return new WaitForSeconds(1.5f); // poți crește dacă vrei să vadă feedback-ul mai mult
        dialoguePanel.SetActive(false);
        feedbackText.text = ""; // opțional, curățare
    }
}
