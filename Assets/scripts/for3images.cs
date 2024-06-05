using UnityEngine;
using UnityEngine.UI;

public class for3imagesr : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public Image image3;
    public KeyCode switchKey = KeyCode.Space; // Key to switch images

    int currentImageIndex = 0;

    void Start()
    {
        // Ensure the first image is visible and the other images are hidden at the start
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check if the switch key is pressed
        if (Input.GetKeyDown(switchKey))
        {
            // Hide the current image
            switch (currentImageIndex)
            {
                case 0:
                    image1.gameObject.SetActive(false);
                    break;
                case 1:
                    image2.gameObject.SetActive(false);
                    break;
                case 2:
                    image3.gameObject.SetActive(false);
                    break;
            }

            // Show the next image if it exists
            if (currentImageIndex < 2)
            {
                currentImageIndex++;
                switch (currentImageIndex)
                {
                    case 1:
                        image2.gameObject.SetActive(true);
                        break;
                    case 2:
                        image3.gameObject.SetActive(true);
                        break;
                }
            }
        }
    }
}