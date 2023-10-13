using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TowerPrefab
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private int priceToDeploy; 

    [SerializeField] private int damage;

    [SerializeField] private float shootDelay;
    public int PriceToDeploy
    {
        get { return priceToDeploy; }
    }
    public int Damage
    {
        get { return damage; }
    }
    public float ShootDelay
    {
        get { return shootDelay; }
    }
    public GameObject Prefab
    {
        get { return prefab; }
    }

}
