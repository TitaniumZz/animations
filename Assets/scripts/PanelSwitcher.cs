using UnityEngine;
using UnityEngine.UI;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;

    public void SwitchPanel()
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false); // Close the current panel
        }

        if (nextPanel != null)
        {
            nextPanel.SetActive(true); // Show the next panel
        }
    }
}
