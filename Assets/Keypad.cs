using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text Ans;
    [SerializeField] private string Answer = "1981";
    [SerializeField] private GameObject photoObject;
    [SerializeField] private Canvas keypadCanvas;

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Execute()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "Correct";
            photoObject.SetActive(true);
            StartCoroutine(DeactivateCanvasAfterDelay(2f));
        }
        else
        {
            Ans.text = "Incorrect";
            StartCoroutine(ClearIncorrectTextAfterDelay(2f));
        }
    }

    private IEnumerator DeactivateCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        keypadCanvas.gameObject.SetActive(false);
    }

    private IEnumerator ClearIncorrectTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Ans.text = "";
    }
}