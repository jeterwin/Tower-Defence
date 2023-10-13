using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Enemy : MonoBehaviour 
{
    public float Speed;
    public List<Waypoint> waypoints = new();
    int curWaypointIndex = 0;

    private void OnEnable()
    {
        FindPath();
        curWaypointIndex = 0;
        transform.position = waypoints[curWaypointIndex].transform.position + new Vector3(0f, 0.5f, 0f);
        gameObject.tag = "enemyBug";
    }
    private void FindPath()
    {
        waypoints.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {
            if (child.TryGetComponent<Waypoint>(out var waypoint))
                waypoints.Add(waypoint);
        }
    }

    void Update ()
	{
        if (curWaypointIndex < waypoints.Count)
        {
            MoveToNextWaypoint();
        }
    }

    private void MoveToNextWaypoint()
    {
        Vector3 pos = waypoints[curWaypointIndex].transform.position;
        Vector3 nextPos = new(pos.x, transform.position.y, pos.z);
        transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * Speed);
        transform.LookAt(nextPos);

        if (Vector3.Distance(transform.position, nextPos) < 0.05f)
        {
            curWaypointIndex++;
        }
        if(curWaypointIndex == waypoints.Count)
            gameObject.SetActive(false);
    }
}

