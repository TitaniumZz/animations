using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Canvas infoCanvas; // Canvas bile�eni i�in bir referans
    private bool canDestroyKnife = false;
    private bool knifeDestroyed = false;
    private GameObject interactableObject;

    void Start()
    {
        infoCanvas.gameObject.SetActive(false); // Canvas'� ba�lang��ta gizle
    }

    void Update()
    {
        if (canDestroyKnife && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(interactableObject);
            canDestroyKnife = false; // Nesne yok edildikten sonra tetiklemeyi durdurmak i�in
            knifeDestroyed = true; // Knife nesnesi yok edildi
            StartCoroutine(ShowCanvas()); // Canvas'� g�ster ve sonra gizle
        }
        else if (knifeDestroyed && interactableObject != null && interactableObject.CompareTag("Balloon") && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(interactableObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Knife"))
        {
            canDestroyKnife = true;
            interactableObject = other.gameObject;
        }
        else if (knifeDestroyed && other.CompareTag("Balloon"))
        {
            interactableObject = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Knife") || (knifeDestroyed && other.CompareTag("Balloon")))
        {
            canDestroyKnife = false;
            interactableObject = null;
        }
    }

    IEnumerator ShowCanvas()
    {
        infoCanvas.gameObject.SetActive(true); // Canvas'� etkinle�tir
        yield return new WaitForSeconds(2); // 2 saniye bekle
        infoCanvas.gameObject.SetActive(false); // Canvas'� devre d��� b�rak
    }
}