using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] int poolSize;
    [SerializeField] [Range(0.1f, 5f)] float spawningTime;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            ActivateEnemy();
            yield return new WaitForSeconds(spawningTime);
        }
    }

    private void ActivateEnemy()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(EnemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }
}
