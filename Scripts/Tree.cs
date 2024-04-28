using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MoveObject
{
    public GameObject kodamaPoint;
    private BoxCollider2D cc;
    private int spawnLimit;

    public override void Start()
    {
        base.Start();
        spawnLimit = Random.Range(4, 7);
        cc = gameObject.GetComponent<BoxCollider2D>();
        for(int i = 0; i < spawnLimit; i++)
        {
            StartCoroutine(SpawnKodamaPoint());
        }
    }
    private IEnumerator SpawnKodamaPoint()
    {
        float spawnDelay = Random.Range(5f, 25f);
        float removeDelay = Random.Range(2f, 3f);

        yield return new WaitForSeconds(spawnDelay);
        GameObject point = pointSummon();

        yield return new WaitForSeconds(removeDelay);

        if (point != null)
            point.GetComponent<Kodamapoint>().DestroyThis();

    }

    public GameObject pointSummon()
    {
        Vector3 treePosition = gameObject.transform.position;
        float randomX = Random.Range(treePosition.x - cc.size.x / 2 + (cc.offset.x), treePosition.x + cc.size.x / 2 + (cc.offset.x));
        float randomY = Random.Range(treePosition.y - cc.size.y / 2 + (cc.offset.y), treePosition.y + cc.size.y / 2 + (cc.offset.y));

        GameObject point = Instantiate(kodamaPoint, new Vector3(randomX, randomY, 0), Quaternion.identity, gameObject.transform);
        return point;
    }

    public override void Update()
    {
        base.Update();

    }
}
