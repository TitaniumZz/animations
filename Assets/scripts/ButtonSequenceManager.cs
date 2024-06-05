
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonSequenceManager : MonoBehaviour
{
    public Button[] buttons;
    public Image feedbackImage;
    public List<Sprite> foldSprites; 
    public Vector2 secondStageSize = new Vector2(50, 50); 

    private Vector2 originalSize; 
    private List<int> sequence = new List<int> { 0, 1, 0, 3, 3, 3, 2, 1, 3, 0 };
    private int currentStep = 0;

    void Start()
    {
        foreach (Button button in buttons)
        {
            Button currentButton = button; 
            currentButton.onClick.AddListener(() => ButtonClicked(currentButton)); 
        }

      
        feedbackImage.sprite = foldSprites[0];
        originalSize = feedbackImage.rectTransform.sizeDelta;
    }

    void ButtonClicked(Button clickedButton)
    {
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);

        if (buttonIndex == sequence[currentStep])
        {
            currentStep++;

            if (currentStep < foldSprites.Count)
            {
                feedbackImage.sprite = foldSprites[currentStep]; 

                if (currentStep == 1) 
                {
                    feedbackImage.rectTransform.sizeDelta = secondStageSize; 
                }
                else if (currentStep != 1 && feedbackImage.rectTransform.sizeDelta != originalSize)
                {
                    feedbackImage.rectTransform.sizeDelta = originalSize; 
                }
            }

            if (currentStep >= sequence.Count)
            {
                Debug.Log("Sequence complete! Paper plane folded.");
                currentStep = 0; 
                feedbackImage.sprite = foldSprites[0]; 
                feedbackImage.rectTransform.sizeDelta = originalSize; 
            }
        }
        else
        {
            Debug.Log("Wrong button clicked. Resetting sequence.");
            currentStep = 0;
            feedbackImage.sprite = foldSprites[0]; 
            feedbackImage.rectTransform.sizeDelta = originalSize;
        }
    }
}

