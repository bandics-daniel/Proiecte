using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickObject : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button checkButton;
    public TextMeshProUGUI feedbackText;
    public SpanishWordChecker checker;

    void OnMouseDown()
    {
        // Verificăm dacă deja s-a răspuns corect
        if (!checker.HasAnsweredCorrectly())
        {
            inputField.interactable = true;
            checkButton.interactable = true;
            feedbackText.text = "Tastează numele obiectului în spaniolă:";
        }
    }
}
