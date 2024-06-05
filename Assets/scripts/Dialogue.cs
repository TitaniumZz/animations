using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class Dialogue : MonoBehaviour
{
    //UI References

    [SerializeField]
    private GameObject DialogueCanvas;

    [SerializeField]
    private TMP_Text speakerText;


    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private Image portraitImage;

    //Dialogue Content
    [SerializeField]
    private string[] speaker;

    [SerializeField]
    [TextArea]
    private string[] dialogueWords;

    [SerializeField]
    private Sprite[] portrait;


    private bool endDialog;
    private bool dialogueActivated;
    private int step = 0;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogueActivated == true)
        {

            if (step >= speaker.Length)
            {
                DialogueCanvas.SetActive(false);
                dialogueActivated = false;
                return;
            }

            DialogueCanvas.SetActive(true);
            speakerText.text = speaker[step];
            dialogueText.text = dialogueWords[step];
            portraitImage.sprite = portrait[step];
            step += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueActivated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueActivated = false;
        DialogueCanvas.SetActive(false);
        step = 0;
       
    }

}
