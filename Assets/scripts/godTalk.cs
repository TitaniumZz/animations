
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class Dialogue : MonoBehaviour
//{
//    public TextMeshProUGUI textComponent;
//    public string[] lines;
//    public float textSpeed;

//    private int index;

//    // Start is called before the first frame update
//    void Start()
//    {
//        textComponent.text = string.Empty;
//        StartDialogue();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            if (textComponent.text == lines[index])
//            {
//                NextLine();
//            }
//            else
//            {
//                StopAllCoroutines();
//                textComponent.text = lines[index];
//            }
//        }
//    }

//    void StartDialogue()
//    {
//        index = 0;
//        StartCoroutine(TypeLine());
//    }

//    IEnumerator TypeLine()
//    {
//        foreach (char c in lines[index].ToCharArray())
//        {
//            textComponent.text += c;
//            yield return new WaitForSeconds(textSpeed);
//        }
//    }

//    void NextLine()
//    {
//        if (index < lines.Length - 1)
//        {
//            index++;
//            textComponent.text = string.Empty;
//            StartCoroutine(TypeLine());
//        }
//        else
//        {
//            gameObject.SetActive(false);
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueGod : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public string nextSceneName; // Specify the next scene to load

    private int index;
    private bool isDialogueComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isDialogueComplete)
            {
                LoadNextScene();
            }
            else if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            isDialogueComplete = true;
            Debug.Log("Dialogue complete. Click to continue.");
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
