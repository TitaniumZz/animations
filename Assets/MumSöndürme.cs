using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CandleScript : MonoBehaviour
{
    // Mumun yanmış halinin sprite'ını burada tutun.
    public Sprite burnedCandleSprite;

    // Orijinal sprite'ı burada saklayın (isteğe bağlı).
    private Sprite originalSprite;

    // Butonun Image bileşenine erişmek için bu değişkeni kullanın.
    private Image candleImage;

    void Start()
    {
        
            // Image bileşenini al.
            candleImage = GetComponent<Image>();
            originalSprite = candleImage.sprite;
            GameManager.instance.RegisterCandle(this);
        
    }

    // Butona tıklandığında çağrılacak fonksiyon.
    public void OnCandleClick()
    {
        if (!GameManager.instance.AllCandlesBurned())
        {
            if (candleImage.sprite != burnedCandleSprite)
            {
                // Mumun sprite'ını değiştir.
                candleImage.sprite = burnedCandleSprite;
                // GameManager'a mumun yandığını bildir.
                GameManager.instance.CandleBurned(this);
            }
        }
    }

    // Mum sprite'ını eski haline döndüren fonksiyon.
    public void RevertCandle()
    {
        candleImage.sprite = originalSprite;
    }
}