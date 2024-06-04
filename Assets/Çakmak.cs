using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyAndShowCanvas : MonoBehaviour
{
    // Açılacak Canvas
    public GameObject canvas;

    void OnDestroy()
    {
        // Canvas'ı aktif hale getir
        if (canvas != null)
        {
            canvas.SetActive(true);
            // Canvas'ı 3 saniye sonra kapatmak için Coroutine başlat
            StartCoroutine(HideCanvasAfterDelay(3f));
        }
    }

    IEnumerator HideCanvasAfterDelay(float delay)
    {
        // Belirtilen süre kadar bekle
        yield return new WaitForSeconds(delay);
        // Canvas'ı devre dışı bırak
        if (canvas != null)
        {
            canvas.SetActive(false);
        }
    }
}