using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
    public float Speed;
    // 
    public List<Waypoint> waypoints = new();
    int curWaypointIndex = 0;
    void Update () 
	{
        if (curWaypointIndex < waypoints.Count)
        {
            Vector3 pos = waypoints[curWaypointIndex].transform.position;
	        Vector3 nextPos = new Vector3(pos.x, transform.position.y, pos.z);
            transform.position = Vector3.MoveTowards(transform.position,nextPos, Time.deltaTime * Speed);
            transform.LookAt(nextPos);
	
	        if(Vector3.Distance(transform.position,nextPos) < 0.05f)
	        {
		        curWaypointIndex++;
	        }    
	    }          
    }   
}

