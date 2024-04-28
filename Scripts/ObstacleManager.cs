using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] treePrefabs;
    public GameObject[] monsterPrefabs;
    public GameObject[] floatingPrefabs;
    public GameObject[] fruitPrefabs;

    private float treeOffset = -2f;

    [Header("Tree")]
    private float treeMinInterval = 6f;
    private float treeMaxInterval = 8f;
    private float treeTimer = 0;

    [Header("Monster")]
    //private int monsterTotal = 4;
    //private int monsterCount = 0;
    //public float[] monsterTiming;
    private float monsterMinInterval = 16f;
    private float monsterMaxInterval = 20f;
    private float monsterTimer = 0;

    [Header("Floating")]
    //private float floatingTime;
    //private float nowRemaining;
    private float floatingMinInterval = 15f;
    private float floatingMaxInterval = 22f;
    private float ringogMinInterval = 5f;
    private float ringoMaxInterval = 8f;
    private float floatingTimer = 0;
    private float fruitTimer = 0;

    void Start()
    {
        SetUpMonsterTiming();
        SetUpFloatingTiming();
    }

    void Update()
    {
        InstantiateTree();
        InstantiateMonster();
        InstantiateFloating();
    }

    private void SetUpFloatingTiming()
    {
        floatingTimer = 15f;
        fruitTimer = 10f;
        //floatingTime = Random.Range(50, 70);
        //nowRemaining = MountainManager.instance.remaining;
    }

    private void SetUpMonsterTiming()
    {
        monsterTimer = 12f;
        //monsterTiming = new float[monsterTotal];
        //monsterTiming[monsterTotal - 1] = (MountainManager.instance.goal / monsterTotal) / 1.5f;
        ////Debug.Log(monsterTiming[monsterTotal - 1]);
        //for (int i = 1; i < monsterTotal; i++)
        //{
        //    monsterTiming[monsterTotal - 1 - i] = (i * (MountainManager.instance.goal / monsterTotal)) + (Random.Range(0, (MountainManager.instance.goal / monsterTotal) / 2));
        //    //Debug.Log(monsterTiming[monsterTotal - 1 - i]);
        //}

    //monsterTiming = new float[] {400, 250, 150};
    }

    private void InstantiateTree()
    {
        treeTimer -= Time.deltaTime;

        if (treeTimer <= 0)
        {
            int randomSpawn = Random.Range(0, treePrefabs.Length);
            Instantiate(treePrefabs[randomSpawn], new Vector3(transform.position.x, transform.position.y + treeOffset, 0), Quaternion.identity, gameObject.transform);
            treeTimer = Random.Range(treeMinInterval, treeMaxInterval);
        }
    }

    private void InstantiateMonster()
    {
        monsterTimer -= Time.deltaTime;

        if (monsterTimer <= 0/*monsterCount < monsterTiming.Length*/)
        {
            if (monsterTimer <= 0 /*MountainManager.instance.remaining < monsterTiming[monsterCount]*/)
            {
                //monsterCount++;
                int randomSpawn = Random.Range(0, monsterPrefabs.Length);
                Instantiate(monsterPrefabs[randomSpawn], new Vector3(transform.position.x, transform.position.y + monsterPrefabs[randomSpawn].GetComponent<Monster>().offset, 0), Quaternion.identity, gameObject.transform);
                monsterTimer = Random.Range(monsterMinInterval, monsterMaxInterval);
            }
        }
    }

    private void InstantiateFloating()
    {
        floatingTimer -= Time.deltaTime;
        fruitTimer -= Time.deltaTime;

        if(floatingTimer <= 0/*nowRemaining - MountainManager.instance.remaining >= floatingTime*/)
        {
            int randomSpawn = Random.Range(0, floatingPrefabs.Length);
            GameObject floating = Instantiate(floatingPrefabs[randomSpawn], new Vector3(transform.position.x, transform.position.y + Random.Range(0, -3.9f), 0), Quaternion.identity, gameObject.transform);
            //SetUpFloatingTiming();
            floatingTimer = Random.Range(floatingMinInterval, floatingMaxInterval);
        }

        if (fruitTimer <= 0/*nowRemaining - MountainManager.instance.remaining >= floatingTime*/)
        {
            int randomSpawn = Random.Range(0, fruitPrefabs.Length);
            GameObject fruit = Instantiate(fruitPrefabs[randomSpawn], new Vector3(transform.position.x, transform.position.y + Random.Range(0, -3.9f), 0), Quaternion.identity, gameObject.transform);
            //SetUpFloatingTiming();
            fruitTimer = Random.Range(ringogMinInterval, ringoMaxInterval);
        }
    }
}
