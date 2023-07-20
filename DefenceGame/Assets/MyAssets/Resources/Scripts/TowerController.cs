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
                // Mathf.Atan2(float y��ǥ��, float x��ǥ��): y�� x�� �޾ƿ� ź��Ʈ�� ���Լ�(��ũ ź��Ʈ)�� ���� radian(����)���� ��ȯ�ϴ� �Լ� 
                // Mathf.Rad2Deg: radian�� ���ϸ� degree(��)�� �ٲ�� ���� ��ȯ�Ѵ�
                // float angle = Mathf.Atan2(enemies[i].transform.position.y, enemies[i].transform.position.x) * Mathf.Rad2Deg;

                // Quaternion.AngleAxis(float ��, Vector3 ���⺤��): ���⺤�͸� ������ ��� ����ŭ ���� ������ Quaternion���� ��ȯ�ϴ� �Լ�
                // transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                // ���� �ִ� ����
                Vector2 direction = enemies[i].transform.position - transform.position;
                // ���� ���� Y�� �����̹Ƿ� up
                transform.up = direction.normalized;

                Debug.Log("����!");
            }
        }
    }
}
