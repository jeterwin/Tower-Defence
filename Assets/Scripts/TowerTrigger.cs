using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerTrigger : MonoBehaviour 
{
	public Tower twr;
    public bool lockE;
	public Transform curTarget;
    void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("enemyBug") && !lockE)
		{   
			twr.target = other.gameObject.transform;            
            curTarget = other.transform;
			lockE = true;
		}
    }

	void Update()
	{
        if (curTarget)
        {
            if (curTarget.CompareTag("Dead"))
            {
                lockE = false;
                twr.target = null;      
                curTarget = null;
            }
            else
                lockE = true;
        }
        if (!curTarget) 
		{
			lockE = false;
        }
		if(curTarget == null)
        {
            FindEnemy();
        }
    }

    private void FindEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestEnemy = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if(distance < maxDistance)
            {
                closestEnemy = enemy.transform;
                maxDistance = distance;
            }
        }
        curTarget = closestEnemy;
        twr.target = curTarget;
    }

    void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("enemyBug") && other.gameObject == curTarget)
		{
			lockE = false;
            twr.target = null;            
        }
	}
}
