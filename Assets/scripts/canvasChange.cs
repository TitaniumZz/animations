using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public Canvas tutorialCanvas;
    public Canvas gameCanvas;

    void Start()
    {
        // Ensure the tutorial canvas is active and the game canvas is inactive at the start
        tutorialCanvas.gameObject.SetActive(true);
        gameCanvas.gameObject.SetActive(false);
    }

    // Call this method to switch from the tutorial canvas to the game canvas
    public void StartGame()
    {
        tutorialCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
    }
}
