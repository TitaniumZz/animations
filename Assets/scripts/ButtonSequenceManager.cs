//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections.Generic;

//public class ButtonSequenceManager : MonoBehaviour
//{

//    public Button[] buttons;
//    private List<int> sequence = new List<int> { 0, 1, 0, 3, 3, 3, 2, 1, 3, 0 };
//    private int currentStep = 0;

//    void Start()
//    {
//        foreach (Button button in buttons)
//        {
//            Button currentButton = button;
//            currentButton.onClick.AddListener(() => ButtonClicked(currentButton));
//        }
//    }

//    void ButtonClicked(Button clickedButton)
//    {
//        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);

//        if (buttonIndex == sequence[currentStep])
//        {
//            currentStep++;

//            if (currentStep >= sequence.Count)
//            {
//                Debug.Log("Sequence complete!");
//                currentStep = 0;
//            }
//        }
//        else
//        {
//            Debug.Log("Wrong button clicked. Resetting sequence.");
//            currentStep = 0;
//    }
//}
//}

//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections.Generic;

//public class ButtonSequenceManager : MonoBehaviour
//{
//    public Button[] buttons;
//    public Image feedbackImage; // Reference to the UI Image component
//    public List<Sprite> foldSprites; // List of sprites representing each folding step

//    private List<int> sequence = new List<int> { 0, 1, 0, 3, 3, 3, 2, 1, 3, 0 };
//    private int currentStep = 0;

//    void Start()
//    {
//        foreach (Button button in buttons)
//        {
//            Button currentButton = button; // Create a local variable inside the loop
//            currentButton.onClick.AddListener(() => ButtonClicked(currentButton)); // Use the local variable
//        }

//        // Initialize the feedback image to the first step
//        feedbackImage.sprite = foldSprites[0];
//    }

//    void ButtonClicked(Button clickedButton)
//    {
//        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);

//        if (buttonIndex == sequence[currentStep])
//        {
//            currentStep++;

//            if (currentStep < foldSprites.Count)
//            {
//                feedbackImage.sprite = foldSprites[currentStep]; // Update the image to the next step
//            }

//            if (currentStep >= sequence.Count)
//            {
//                Debug.Log("Sequence complete! Paper plane folded.");
//                currentStep = 0; // Reset sequence
//                feedbackImage.sprite = foldSprites[0]; // Reset to the first step image
//            }
//        }
//        else
//        {
//            Debug.Log("Wrong button clicked. Resetting sequence.");
//            currentStep = 0; // Reset sequence
//            feedbackImage.sprite = foldSprites[0]; // Reset to the first step image
//        }
//    }
//}
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonSequenceManager : MonoBehaviour
{
    public Button[] buttons;
    public Image feedbackImage; // Reference to the UI Image component
    public List<Sprite> foldSprites; // List of sprites representing each folding step
    public Vector2 secondStageSize = new Vector2(50, 50); // New size for the second stage

    private Vector2 originalSize; // To store the original size of the image
    private List<int> sequence = new List<int> { 0, 1, 0, 3, 3, 3, 2, 1, 3, 0 };
    private int currentStep = 0;

    void Start()
    {
        foreach (Button button in buttons)
        {
            Button currentButton = button; // Create a local variable inside the loop
            currentButton.onClick.AddListener(() => ButtonClicked(currentButton)); // Use the local variable
        }

        // Initialize the feedback image to the first step
        feedbackImage.sprite = foldSprites[0];
        originalSize = feedbackImage.rectTransform.sizeDelta; // Store the original size
    }

    void ButtonClicked(Button clickedButton)
    {
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);

        if (buttonIndex == sequence[currentStep])
        {
            currentStep++;

            if (currentStep < foldSprites.Count)
            {
                feedbackImage.sprite = foldSprites[currentStep]; // Update the image to the next step

                if (currentStep == 1) // Second stage (index 1)
                {
                    feedbackImage.rectTransform.sizeDelta = secondStageSize; // Change the size
                }
                else if (currentStep != 1 && feedbackImage.rectTransform.sizeDelta != originalSize)
                {
                    feedbackImage.rectTransform.sizeDelta = originalSize; // Reset to original size if not in second stage
                }
            }

            if (currentStep >= sequence.Count)
            {
                Debug.Log("Sequence complete! Paper plane folded.");
                currentStep = 0; // Reset sequence
                feedbackImage.sprite = foldSprites[0]; // Reset to the first step image
                feedbackImage.rectTransform.sizeDelta = originalSize; // Reset to original size
            }
        }
        else
        {
            Debug.Log("Wrong button clicked. Resetting sequence.");
            currentStep = 0; // Reset sequence
            feedbackImage.sprite = foldSprites[0]; // Reset to the first step image
            feedbackImage.rectTransform.sizeDelta = originalSize; // Reset to original size
        }
    }
}

