using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Sahnedeki tüm mum butonlarýný tutan liste.
    private List<CandleScript> candles = new List<CandleScript>();

    // Yanan mum sayýsý.
    private int burnedCandleCount = 0;

    // Coroutine kontrolü için deðiþken.
    private Coroutine revertCoroutine = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Mumu listeye ekleme.
    public void RegisterCandle(CandleScript candle)
    {
        candles.Add(candle);
    }

    // Bir mum yandýðýnda çaðrýlýr.
    public void CandleBurned(CandleScript candle)
    {
        burnedCandleCount++;

        // Eðer tüm mumlar yandýysa.
        if (burnedCandleCount == candles.Count)
        {
            if (revertCoroutine != null)
            {
                StopCoroutine(revertCoroutine);
                revertCoroutine = null;
            }
        }
        else
        {
            if (revertCoroutine == null)
            {
                revertCoroutine = StartCoroutine(CheckBurnedCandles());
            }
        }
    }

    // Tüm mumlar yandý mý kontrolü.
    public bool AllCandlesBurned()
    {
        return burnedCandleCount == candles.Count;
    }

    // Mumlarýn durumunu kontrol eden coroutine.
    private IEnumerator CheckBurnedCandles()
    {
        yield return new WaitForSeconds(2f);

        // Eðer tüm mumlar yanmadýysa, eski haline döndür.
        if (burnedCandleCount < candles.Count)
        {
            foreach (CandleScript candle in candles)
            {
                candle.RevertCandle();
            }
            burnedCandleCount = 0;
        }

        revertCoroutine = null;
    }
}