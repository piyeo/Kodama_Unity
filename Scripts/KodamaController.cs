using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class KodamaController : MonoBehaviour
{
    public GameObject pointZone;
    private GameObject kodamaZone;
    private BoxCollider2D cc;
    private float RandomX;
    private float RandomY;
    private Vector3 zonePosition;
    private Vector3 obstaclePosition;
    public bool canMoveToObs;
    public bool isAdded;
    public bool isDamaged;

    void Start()
    {
        canMoveToObs = false;
        isAdded = false;
        isDamaged = false;
        kodamaZone = GameObject.Find("kodamaZone");
        cc = kodamaZone.GetComponent<BoxCollider2D>();
        RandomX = Random.Range(kodamaZone.transform.position.x - cc.size.x / 2, kodamaZone.transform.position.x + cc.size.x / 2);
        RandomY = Random.Range(kodamaZone.transform.position.y - cc.size.y / 2, kodamaZone.transform.position.y + cc.size.y / 2);
        zonePosition = new Vector3(RandomX, RandomY, 1);
    }

    void Update()
    {
        if(canMoveToObs)
            MoveToObstacle();
        else
            MoveToBehind();
    }

    private void MoveToBehind()
    {
        if(gameObject.transform.position == zonePosition && !isAdded)
        {
            MountainManager.instance.AddKodama(GetComponent<KodamaController>());
            isAdded = true;
        }
        if (gameObject.transform.position != zonePosition)
            transform.position = Vector3.MoveTowards(transform.position, zonePosition, 30.0f * Time.deltaTime);
    }

    public void MoveToObstacle()
    {
        //transform.SetParent(pointZone.transform.parent.transform);
        obstaclePosition = pointZone.transform.position;
        if (gameObject.transform.position != obstaclePosition)
            transform.position = Vector3.MoveTowards(transform.position, obstaclePosition, 40.0f * Time.deltaTime);

        if (gameObject.transform.position == obstaclePosition && !isDamaged)
        {
            pointZone.GetComponentInParent<Obstacle>().Damage();
            isDamaged = true;
        }
    }
}
