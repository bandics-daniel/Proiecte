using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrophyPopup : MonoBehaviour
{
    public GameObject popupPanel;   // Panelul cu trofeul
    public GameObject endPanel;     // Panelul final cu butoanele
    public float displayTime = 4f;  // Cât timp e vizibil trofeul
    public AudioSource trophySound; // Efectul sonor de trofeu

    public void ShowTrophy()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);

            if (trophySound != null)
                trophySound.Play();

            StartCoroutine(HideAfterDelay());
        }
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);

        if (popupPanel != null)
            popupPanel.SetActive(false);

        if (endPanel != null)
            endPanel.SetActive(true);  // Afișează panelul final cu butoane
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
