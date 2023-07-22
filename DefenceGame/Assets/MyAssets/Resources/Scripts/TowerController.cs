using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public Vector2 distance = Vector2.zero;
    private List<GameObject> enemies;

    void Start()
    {
        enemies = GameManager.instance.enemies;
    }

    void Update()
    {
        for (int i = 0; i < enemies.Count;)
        {
            distance = transform.position - enemies[i].transform.position;

            if (distance.magnitude <= 3.0f)
            {
                // Mathf.Atan2(float y��ǥ��, float x��ǥ��): y�� x�� �޾ƿ� ź��Ʈ�� ���Լ�(��ũ ź��Ʈ)�� ���� radian(����)���� ��ȯ�ϴ� �Լ� 
                // Mathf.Rad2Deg: radian�� ���ϸ� degree(��)�� �ٲ�� ���� ��ȯ�Ѵ�
                // float angle = Mathf.Atan2(enemies[i].transform.position.y, enemies[i].transform.position.x) * Mathf.Rad2Deg;
                // Quaternion.AngleAxis(float ��, Vector3 ���⺤��): ���⺤�͸� ������ ��� ����ŭ ���� ������ Quaternion���� ��ȯ�ϴ� �Լ�
                // transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);


                // ���� �ִ� ����
                Vector2 direction = enemies[i].transform.localPosition - transform.position;
                // ���� ���� Y�� �����̹Ƿ� up
                transform.up = direction.normalized * -1;

                Bullet bullet = BulletPool.GetObject();
                bullet.transform.position = new Vector2(transform.position.x, transform.position.y) + direction.normalized;
                bullet.Shoot(direction.normalized);

                Debug.Log("����!");

                break;
            }
            else
            {
                i += 1;
            }
        }
    }
}
