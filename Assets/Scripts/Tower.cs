using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour 
{
	public Transform shootElement;
    public GameObject Towerbug;
    public Transform LookAtObj;    
    public GameObject bullet;
    public GameObject DestroyParticle;
    public Vector3 impactNormal_2;
    public Transform target;

    private TowerPrefab towerPrefab;
    public TowerPrefab TowerPrefab
    {
        get { return towerPrefab; }
        set { towerPrefab = value; }
    }
    bool canShoot = true;
    public Animator anim_2; 
    private float homeY;
    float timeElapsed = 0f;
    void Start()
    {
        anim_2 = GetComponent<Animator>();
        homeY = LookAtObj.transform.localRotation.eulerAngles.y;
    }
    void Update() 
    {
        if (target)
        {  
            Vector3 dir = target.transform.position - LookAtObj.transform.position;
            dir.y = 0; 
            Quaternion rot = Quaternion.LookRotation(dir);                
            LookAtObj.transform.rotation = Quaternion.Slerp(LookAtObj.transform.rotation, rot, 5 * Time.deltaTime);
            if (canShoot)
            {
                StartCoroutine(shoot());
            }
        }
        else
        {
            Quaternion home = new Quaternion (0, homeY, 0, 1);
            LookAtObj.transform.rotation = Quaternion.Slerp(LookAtObj.transform.rotation, home, Time.deltaTime);                        
        }
    }

	IEnumerator shoot()
	{
		canShoot = false;
        if (target)
        {
            GameObject b = Instantiate(bullet, shootElement.position, Quaternion.identity);
            b.GetComponent<TowerBullet>().target = target;
            b.GetComponent<TowerBullet>().twr = towerPrefab;
        }
        timeElapsed = 0;
        while(timeElapsed <= towerPrefab.ShootDelay)
        {
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        canShoot = true;
	}
}



