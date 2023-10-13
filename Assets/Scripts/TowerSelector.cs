using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelector : MonoBehaviour
{
    [SerializeField] private List<TowerPrefab> towerPrefabList;
    [SerializeField] private int currentTower = 0;
    public List<TowerPrefab> TowerPrefabList
    {
        get { return towerPrefabList; }
    }
    public int CurrentTower
    {
        get { return currentTower; } 
    }
    public void SelectTower(int towerIndex)
    {
        currentTower = towerIndex;
    }
}
