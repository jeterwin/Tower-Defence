using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlaceable = false;
    [SerializeField] private TowerPrefab tower;
    [SerializeField] private CoordinateLabeler coordinateLabeler;
    private CurrencySystem currencySystem;
    private void Awake()
    {
        currencySystem = FindObjectOfType<CurrencySystem>();
    }
    public bool IsPlaceable
    {
        get { return isPlaceable; }
    }
    private void OnMouseDown()
    {
        if(isPlaceable && currencySystem.Currency >= tower.PriceToDeploy)
        {
            GameObject newTower = Instantiate(tower.Prefab, transform);
            newTower.GetComponent<Tower>().TowerPrefab = tower;
            currencySystem.WithdrawCurrency(tower.PriceToDeploy);
            isPlaceable = false;
            coordinateLabeler.enabled = false;
        }
    }
}
