using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CandleScript : MonoBehaviour
{

    public Sprite burnedCandleSprite;


    private Sprite originalSprite;


    private Image candleImage;

    void Start()
    {
        
         
            candleImage = GetComponent<Image>();
            originalSprite = candleImage.sprite;
            GameManager.instance.RegisterCandle(this);
        
    }


    public void OnCandleClick()
    {
        if (!GameManager.instance.AllCandlesBurned())
        {
            if (candleImage.sprite != burnedCandleSprite)
            {
              
                candleImage.sprite = burnedCandleSprite;
              
                GameManager.instance.CandleBurned(this);
            }
        }
    }


    public void RevertCandle()
    {
        candleImage.sprite = originalSprite;
    }
}