using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int coins;
    [SerializeField] private TMP_Text coinsDisplay;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void Update()
    {
        coinsDisplay.text = coins.ToString();
    }

    public void ChangeCoins(int amount)
    {
        coins += amount;
    }
}
