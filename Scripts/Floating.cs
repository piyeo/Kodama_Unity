using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : Obstacle
{
    private bool ishealed = false;
    public override void Start()
    {
        base.Start();
        speed = Random.Range(1.6f, 3.0f);
        if(gameObject.CompareTag("Fruit"))
            hp = Random.Range(2, 5);
        if (gameObject.CompareTag("Floating"))
            hp = Random.Range(3, 6);
        //if (MountainManager.instance.remaining > (MountainManager.instance.goal / 1.2f))
        //    hp = Random.Range(1,3);
        //else if (MountainManager.instance.remaining > (MountainManager.instance.goal / 2f))
        //    hp = Random.Range(1,4);
        //else if (MountainManager.instance.remaining > (MountainManager.instance.goal / 3f))
        //    hp = Random.Range(2,4);
        //else if (MountainManager.instance.remaining > (MountainManager.instance.goal / 4f))
        //{
        //    speed = 2f;
        //    hp = Random.Range(3, 4);
        //}
    }

    public override void Update()
    {
        base.Update();
        PointClick();
    }

    public override void PointAttack()
    {
        base.PointAttack();
        MountainManager.instance.KodamaToObstacle(gameObject, gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("FloatingJudge"))
        {
            if (gameObject.CompareTag("Floating"))
            {
                AudioManager.instance.PlaySFXPitch(11);
                MountainManager.instance.StartDecrease((hp-damage) * 3f);
                MountainManager.instance.achieveD = false;
            }
            DestroyObstacle();
        }
    }

    public override void DestroyObstacle()
    {
        if (hp <= damage && !ishealed && gameObject.CompareTag("Fruit"))
        {
            AudioManager.instance.PlaySFX(8);
            MountainManager.instance.currentStamina += 10f;
            ishealed = true;
        }
        else if(gameObject.CompareTag("Floating"))
        {
            AudioManager.instance.PlaySFXPitch(11);
        }
        base.DestroyObstacle();
    }

}
