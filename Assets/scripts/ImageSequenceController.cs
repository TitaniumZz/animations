using UnityEngine;
using UnityEngine.UI;

public class ImageSequenceController : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public KeyCode switchKey = KeyCode.Space; // Key to switch images

    bool hasSwitched = false; // Flag to track if the images have been switched

    void Start()
    {
        // Ensure the first image is visible and the second image is hidden at the start
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check if the switch key is pressed and the images haven't been switched yet
        if (Input.GetKeyDown(switchKey) && !hasSwitched)
        {
            // Toggle the visibility of the images
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(true);
            hasSwitched = true; // Set the flag to true
        }
        // Check if the switch key is pressed and the images have been switched
        else if (Input.GetKeyDown(switchKey) && hasSwitched)
        {
            // Hide the second image
            image2.gameObject.SetActive(false);
        }
    }
}