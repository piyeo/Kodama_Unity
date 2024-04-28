using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Obstacle
{
    public GameObject kodamaToObstacle;
    
    public override void Start()
    {
        base.Start();
        speed = Random.Range(1.4f, 1.9f);
        if (MountainManager.instance.remaining <= 200)
            hp = Random.Range(7, 9);
        else if (MountainManager.instance.remaining <= 400)
            hp = Random.Range(8, 11);
        else if (MountainManager.instance.remaining <= 600)
            hp = Random.Range(9, 12);
        else if (MountainManager.instance.remaining <= 800)
            hp = Random.Range(10, 13);
        else if (MountainManager.instance.remaining > 800)
            hp = Random.Range(11, 14);
        //if (MountainManager.instance.remaining > (MountainManager.instance.goal / 1.2f))
        //    hp = Random.Range(5, 9);
        //else if (MountainManager.instance.remaining > (MountainManager.instance.goal / 2f))
        //    hp = Random.Range(8, 13);
        //else if (MountainManager.instance.remaining > (MountainManager.instance.goal / 3f))
        //    hp = Random.Range(12, 16);
        //else if (MountainManager.instance.remaining > (MountainManager.instance.goal / 4f))
        //    hp = Random.Range(15, 19);
    }

    public override void Update()
    {
        base.Update();
        PointClick();
    }

    public override void PointAttack()
    {
        base.PointAttack();
        GameObject toObj = Instantiate(kodamaToObstacle,new Vector3(Random.Range(transform.position.x - GetComponent<BoxCollider2D>().size.x / 2, transform.position.x + GetComponent<BoxCollider2D>().size.x / 2), Random.Range(transform.position.y - GetComponent<BoxCollider2D>().size.y / 2, transform.position.y + GetComponent<BoxCollider2D>().size.y / 2), 1),Quaternion.identity,gameObject.transform);
        MountainManager.instance.KodamaToObstacle(toObj, gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("MonsterJudge"))
        {
            float clearRate = Random.Range(0, 100);
            float judgeRate = (((float)damage / hp) * 100f) + plusRate;
            if (clearRate <= judgeRate)
            {
                if (judgeRate <= 30)
                    MountainManager.instance.achieveC = true;
                AudioManager.instance.PlaySFX(9);
                DestroyObstacle();
            }
            else
            {
                MountainManager.instance.achieveD = false;
                MountainManager.instance.KilledByMonster();
            }
        }
    }

    public void RateUp()
    {
        StartCoroutine(Blink());
    }

    public IEnumerator Blink()
    {
        var alpha = 0f;
        var color = GetComponent<SpriteRenderer>().color;
        color.a = alpha;
        GetComponent<SpriteRenderer>().color = color;
        plusRate += 10f;
        yield return new WaitForSeconds(.2f);
        alpha = 1f;
        color = GetComponent<SpriteRenderer>().color;
        color.a = alpha;
        GetComponent<SpriteRenderer>().color = color;
    }
}
