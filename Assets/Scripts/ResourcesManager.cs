using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private int coins;

    public static ResourcesManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CoinUp(int amount)
    {
        coins += amount;
        RefreshTextCoin();
    }

    private void CoinsSpend(int amount)
    {
        coins -= amount;
        RefreshTextCoin();
    }
    private void RefreshTextCoin()
    {
        coinText.text= coins.ToString();
    }
}
