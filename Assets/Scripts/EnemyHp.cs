using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour 
{
    public int EnemyHP = 30;
    public int Coins = 25;
    private int resetHP;
    private CurrencySystem currencySystem;
    private void Awake()
    {
        currencySystem = FindObjectOfType<CurrencySystem>();
        resetHP = EnemyHP;
    }
    
    public void Dmg(int DMGcount)
    {
        EnemyHP -= DMGcount;
    }
    private void Update()
    {        
        if (EnemyHP <= 0)
        {
            currencySystem.DepositCurrency(Coins);
            gameObject.SetActive(false);
            gameObject.tag = "Dead";
            EnemyHP = resetHP;
        }
    }
    
}
