using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RicochetTower : MonoBehaviour
{
    public Vector2 distance = Vector2.zero;
    private List<GameObject> enemies;

    private float time;

    public float Damage { get; private set; }
    public float ShootRate { get; private set; }
    public float Range { get; private set; }

    private void Start()
    {
        Damage = 5.0f;
        ShootRate = 0.5f;
        Range = 3.0f;
        enemies = GameManager.instance.enemies;
        time = 0f;
    }
    void Update()
    {
        time += Time.deltaTime;

        for (int i = 0; i < enemies.Count;)
        {
            distance = transform.position - enemies[i].transform.position;

            // ���� �ִ� ����
            Vector3 direction = enemies[i].transform.position - transform.position;

            if (distance.magnitude <= Range)
            {
                // Mathf.Atan2(float y��ǥ��, float x��ǥ��): y�� x�� �޾ƿ� ź��Ʈ�� ���Լ�(��ũ ź��Ʈ)�� ���� radian(����)���� ��ȯ�ϴ� �Լ� 
                // Mathf.Rad2Deg: radian�� ���ϸ� degree(��)�� �ٲ�� ���� ��ȯ�Ѵ�
                // float angle = Mathf.Atan2(enemies[i].transform.position.y, enemies[i].transform.position.x) * Mathf.Rad2Deg;
                // Quaternion.AngleAxis(float ��, Vector3 ���⺤��): ���⺤�͸� ������ ��� ����ŭ ���� ������ Quaternion���� ��ȯ�ϴ� �Լ�
                // transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                // ���� ���� Y�� �����̹Ƿ� up
                // transform.up = direction.normalized * -1f;
                if (direction.x < 0f)
                {
                    SpriteRenderer sRenderer = GetComponentInChildren<SpriteRenderer>();
                    sRenderer.flipX = false;
                }
                else if (direction.x >= 0f)
                {
                    SpriteRenderer sRenderer = GetComponentInChildren<SpriteRenderer>();
                    sRenderer.flipX = true;
                }

                if (time >= ShootRate)
                {
                    time = 0;

                    ShootBullet(direction);
                    Debug.LogFormat("����! , Time : {0}", time);
                }

                break;
            }
            else
            {
                i += 1;
            }
        }
    }

    public void LevelUpTower()
    {
        Damage *= 2;
        ShootRate /= 2;
        Range += 0.5f;
    }

    public void ShootBullet(Vector3 direct_)
    {
        Bullet bullet = BulletPool.GetObject();
        bullet.tower = gameObject;
        bullet.SetDamage(Damage);
        bullet.range = Range;
        bullet.transform.position = transform.position + direct_.normalized / 10;
        bullet.Shoot(direct_.normalized);
    }
}
