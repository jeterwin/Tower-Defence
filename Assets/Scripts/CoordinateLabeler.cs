using TMPro;
using UnityEngine;

//[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    private TextMeshPro textLabel;
    private Vector2Int coordinates;
    private Waypoint waypoint;
    private void Awake()
    {
        textLabel = GetComponent<TextMeshPro>();
        waypoint = transform.parent.GetComponent<Waypoint>();
    }
    private void Start()
    {
        textLabel.enabled = waypoint.IsPlaceable;
    }
    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
        }
        else
        {
            textLabel.enabled = false;
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        textLabel.text = coordinates.x + "," + coordinates.y;
        transform.parent.name = "(" + textLabel.text + ")";
    }
}
