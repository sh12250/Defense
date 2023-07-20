using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public Vector2 distance = Vector2.zero;
    private GameObject[] enemies;

    void Start()
    {
        enemies = GameManager.instance.enemies;
    }

    void Update()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            distance = transform.position - enemies[i].transform.position;

            if (distance.magnitude <= 10f)
            {
                // Mathf.Atan2(float y좌표값, float x좌표값): y와 x를 받아와 탄젠트의 역함수(아크 탄젠트)를 구해 radian(라디안)으로 반환하는 함수 
                // Mathf.Rad2Deg: radian에 곱하면 degree(도)로 바뀌는 값을 반환한다
                // float angle = Mathf.Atan2(enemies[i].transform.position.y, enemies[i].transform.position.x) * Mathf.Rad2Deg;

                // Quaternion.AngleAxis(float 도, Vector3 방향벡터): 방향벡터를 축으로 삼아 도만큼 돌린 방향을 Quaternion으로 반환하는 함수
                // transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                // 적이 있는 방향
                Vector2 direction = enemies[i].transform.position - transform.position;
                // 앞이 양의 Y축 방향이므로 up
                transform.up = direction.normalized;

                Debug.Log("공격!");
            }
        }
    }
}
