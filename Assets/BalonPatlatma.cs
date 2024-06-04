using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Canvas infoCanvas; // Canvas bileþeni için bir referans
    public Canvas info;
    private bool canDestroyKnife = false;
    private bool knifeDestroyed = false;
    private GameObject interactableObject;
    public AudioSource Pat;
    public AudioSource Ahhað;
    public GameObject Pasta;

    void Start()
    {
        infoCanvas.gameObject.SetActive(false); // Canvas'ý baþlangýçta gizle
    }

    void Update()
    {
        if (canDestroyKnife && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(interactableObject);
            canDestroyKnife = false; // Nesne yok edildikten sonra tetiklemeyi durdurmak için
            knifeDestroyed = true; // Knife nesnesi yok edildi
            StartCoroutine(ShowCanvas()); // Canvas'ý göster ve sonra gizle
        }
        else if (knifeDestroyed && interactableObject != null && interactableObject.CompareTag("Balloon") && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(interactableObject);   
            Pat.Play();

        }
        else if (knifeDestroyed && interactableObject != null && interactableObject.CompareTag("Balloon2") && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(interactableObject);
            Pasta.SetActive(true);
            Ahhað.Play();
            StartCoroutine(ShowCanvas2());
            
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
        else if (knifeDestroyed && other.CompareTag("Balloon2"))
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
        infoCanvas.gameObject.SetActive(true); // Canvas'ý etkinleþtir
        yield return new WaitForSeconds(2); // 2 saniye bekle
        infoCanvas.gameObject.SetActive(false); // Canvas'ý devre dýþý býrak
    }

    IEnumerator ShowCanvas2()
    {
        info.gameObject.SetActive(true); // Canvas'ý etkinleþtir
        yield return new WaitForSeconds(2); // 2 saniye bekle
        info.gameObject.SetActive(false); // Canvas'ý devre dýþý býrak
    }
}