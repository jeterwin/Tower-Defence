using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlaceable = false;
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private CoordinateLabeler coordinateLabeler;
    private void Start()
    {
        coordinateLabeler = GetComponentInChildren<CoordinateLabeler>();
    }
    public bool IsPlaceable
    {
        get { return isPlaceable; }
    }
    private void OnMouseDown()
    {
        if(isPlaceable)
        {
            Instantiate(towerPrefab, transform);
            isPlaceable = false;
            coordinateLabeler.enabled = false;
        }
    }
}
