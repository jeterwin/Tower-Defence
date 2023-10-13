using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlaceable = false;
    [SerializeField] private CoordinateLabeler coordinateLabeler;
    private TowerSelector towerSelector;
    private CurrencySystem currencySystem;
    private void Awake()
    {
        currencySystem = FindObjectOfType<CurrencySystem>();
        towerSelector = FindObjectOfType<TowerSelector>();
    }
    public bool IsPlaceable
    {
        get { return isPlaceable; }
    }
    private void OnMouseDown()
    {
        if(isPlaceable && currencySystem.Currency >= towerSelector.TowerPrefabList[towerSelector.CurrentTower].PriceToDeploy)
        {
            GameObject newTower = Instantiate(towerSelector.TowerPrefabList[towerSelector.CurrentTower].Prefab, transform);
            newTower.GetComponent<Tower>().TowerPrefab = towerSelector.TowerPrefabList[towerSelector.CurrentTower];
            currencySystem.WithdrawCurrency(towerSelector.TowerPrefabList[towerSelector.CurrentTower].PriceToDeploy);
            isPlaceable = false;
            coordinateLabeler.enabled = false;
        }
    }
}
