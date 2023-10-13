using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    [SerializeField] private int currency = 100;

    [SerializeField] private TextMeshProUGUI currencyText;
    public int Currency
    {
        get { return currency; }
    }
    private void Awake()
    {
        UpdateCurrency();
    }
    public void WithdrawCurrency(int amount)
    {
        currency -= amount;
        UpdateCurrency();
    }

    public void DepositCurrency(int amount)
    {
        currency += amount;
        UpdateCurrency();
    }

    private void UpdateCurrency()
    {
        currencyText.text = currency.ToString();
    }
}
