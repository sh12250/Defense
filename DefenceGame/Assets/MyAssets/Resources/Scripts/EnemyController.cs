using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject[] attackLine = default;

    public int randNum = 0;

    public int level;
    public float healthMax;
    public float health;
    public float speed = 1.0f;

    public int targetIdx = 0;
    public Vector3 targetPos = default;

    void Start()
    {
        randNum = Random.Range(0, 2);

        switch (randNum)
        {
            case 0:
                attackLine = GameManager.instance.attackLine1;
                break;
            case 1:
                attackLine = GameManager.instance.attackLine2;
                break;
        }

        targetPos = attackLine[targetIdx].transform.position;
    }

    void Update()
    {
        if (targetIdx != 11)
        {
            // if (gameObject.transform.position != targetPos)
            if (transform.position.x > targetPos.x + 0.1f || transform.position.x < targetPos.x - 0.1f ||
                transform.position.y > targetPos.y + 0.1f || transform.position.y < targetPos.y - 0.1f)
            {
                transform.Translate((targetPos - transform.position).normalized * speed * Time.deltaTime);
            }
            // else if (transform.position == targetPos)
            else if (transform.position.x <= targetPos.x + 0.1f || transform.position.x >= targetPos.x - 0.1f ||
                     transform.position.y <= targetPos.y + 0.1f || transform.position.y >= targetPos.y - 0.1f)
            {
                if (targetIdx < 10)
                {
                    targetIdx += 1;
                    targetPos = attackLine[targetIdx].transform.position;
                }
            }
        }

        if (health <= 0)
        {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
