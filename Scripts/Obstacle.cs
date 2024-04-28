using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MoveObject
{
    public int hp;
    public int damage = 0;
    public int damageCount = 0;
    public float plusRate = 0;
    private float downInterval = 0;
    private float downReset = 0;
    public float offset = 0;
    private bool isCliked = false;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public virtual void Damage()
    {
        damage++;
    }

    public virtual void DestroyObstacle()
    {
        Destroy(gameObject);
    }

    public void PointClick()
    {

        if (!MountainManager.instance.gameState)
            return;
        downInterval -= Time.deltaTime;
        downReset -= Time.deltaTime;

        if (hp == damage)
        {
            Invoke("DestroyObstacle", 0.2f);
            return;
        }

        if (Input.GetMouseButtonDown(0) && MountainManager.instance.currentKodama > 0 && damageCount != hp)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.GetComponent<Kodamapoint>() != null)
                        break;

                    if (hit.collider.gameObject == gameObject)
                    {
                        damageCount++;
                        PointAttack();
                        downInterval = 0.3f;
                        isCliked = true;
                        break;
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isCliked = false;
            downInterval = 0;
            downReset = 0;
        }
        if (Input.GetMouseButton(0) && downInterval < 0 && isCliked && downReset < 0 && damageCount != hp)
        {
            damageCount++;
            downReset = 0.15f;
            PointAttack();
        }
    }

    public virtual void PointAttack()
    {
        AudioManager.instance.PlaySFXPitch(5);
    }
}
