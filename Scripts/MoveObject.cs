using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 1.2f; // �ړ����x

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

        // ����20�x�̕������x�N�g���ŕ\��
        Vector2 direction = new Vector2(-Mathf.Cos(3f * Mathf.Deg2Rad), -Mathf.Sin(4f * Mathf.Deg2Rad));

        // �x�N�g���𐳋K�����đ��x����Z���A���Ԃɉ����Ĉړ�������
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public virtual void JudgeDestroy()
    {

    }
}
