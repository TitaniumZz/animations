using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private List<CandleScript> candles = new List<CandleScript>();

    private int burnedCandleCount = 0;

    private Coroutine revertCoroutine = null;

    public GameObject MumYakýldý;

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


    public void RegisterCandle(CandleScript candle)
    {
        candles.Add(candle);
    }

   
    public void CandleBurned(CandleScript candle)
    {
        burnedCandleCount++;

        
        if (burnedCandleCount == candles.Count)
        {
            if (revertCoroutine != null)
            {
                StopCoroutine(revertCoroutine);
                MumYakýldý.SetActive(true);
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

   
    public bool AllCandlesBurned()
    {     
        return burnedCandleCount == candles.Count;
        
    }

   
    private IEnumerator CheckBurnedCandles()
    {
        yield return new WaitForSeconds(3f);

       
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