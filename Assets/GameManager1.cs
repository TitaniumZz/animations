using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Sahnedeki t�m mum butonlar�n� tutan liste.
    private List<CandleScript> candles = new List<CandleScript>();

    // Yanan mum say�s�.
    private int burnedCandleCount = 0;

    // Coroutine kontrol� i�in de�i�ken.
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

    // Bir mum yand���nda �a�r�l�r.
    public void CandleBurned(CandleScript candle)
    {
        burnedCandleCount++;

        // E�er t�m mumlar yand�ysa.
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

    // T�m mumlar yand� m� kontrol�.
    public bool AllCandlesBurned()
    {
        return burnedCandleCount == candles.Count;
    }

    // Mumlar�n durumunu kontrol eden coroutine.
    private IEnumerator CheckBurnedCandles()
    {
        yield return new WaitForSeconds(2f);

        // E�er t�m mumlar yanmad�ysa, eski haline d�nd�r.
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