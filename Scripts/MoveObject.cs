using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 1.2f; // 移動速度

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        if (!MountainManager.instance.gameState)
            return;

        // 左下20度の方向をベクトルで表す
        Vector2 direction = new Vector2(-Mathf.Cos(3f * Mathf.Deg2Rad), -Mathf.Sin(4f * Mathf.Deg2Rad));

        // ベクトルを正規化して速度を乗算し、時間に応じて移動させる
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public virtual void JudgeDestroy()
    {

    }
}
