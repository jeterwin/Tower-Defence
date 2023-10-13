using UnityEngine;
using System.Collections;

public class TowerBullet : MonoBehaviour {

    public float Speed;
    public Transform target;
    public GameObject impactParticle; // bullet impact
    
    public Vector3 impactNormal; 
    Vector3 lastBulletPosition; 
    public TowerPrefab twr;    
    float i = 0.05f; // delay time of bullet destruction

    
    void Update() 
    {
        if(!target.gameObject.activeInHierarchy)
            Destroy(gameObject);
        if (target) 
        {        
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * Speed); 
            lastBulletPosition = target.transform.position; 
        }
        else          
        {     
            transform.position = Vector3.MoveTowards(transform.position, lastBulletPosition, Time.deltaTime * Speed); 
            if (transform.position == lastBulletPosition) 
            {
                Destroy(gameObject,i);
                if (impactParticle != null) 
                {
                    impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal));
                    Destroy(impactParticle, 3);
                    return;
                }
            }
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.transform == target)
        {
            target.GetComponent<EnemyHp>().Dmg(twr.Damage); 
            Destroy(gameObject);
            return;  
        }
    }
}



