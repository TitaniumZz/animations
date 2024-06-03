using UnityEngine;
using UnityEngine.UI;

public class BasketKontrol : MonoBehaviour
{
    public AudioSource Audio;// Basket yazýsýnýn metin nesnesi

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Top")) // Tetikleyici "Top" etiketine sahipse
        {
            Debug.Log("Basket oldu!"); // Debug logunu yazdýr
            Audio.Play(); // Ses dosyasýný çal
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, other.GetComponent<Rigidbody2D>().velocity.y); // Topun yatay hýzýný sýfýrla
            Invoke("SesDurdur", 2.5f); // 5 saniye sonra sesi durdur
        }
    }

    void SesDurdur()
    {
        Audio.Stop(); // Ses dosyasýný durdur
    }
}