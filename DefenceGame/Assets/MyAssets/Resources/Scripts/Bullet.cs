using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject tower;
    private float damage;
    private Vector3 direction;

    void Update()
    {
        transform.Translate(0f, 0.1f, 0f);

        Vector2 distance = gameObject.transform.position - tower.transform.position;
        if (distance.magnitude >= 3.0f && gameObject.activeInHierarchy)
        {
            DestroyBullet();
        }
    }

    public void SetDamage(float damage_)
    {
        damage = damage_;
    }

    public void Shoot(Vector3 direction_)
    {
        this.direction = direction_;
        transform.up = direction_.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") && gameObject.activeInHierarchy)
        {
            EnemyController eCon = collision.gameObject.GetComponent<EnemyController>();
            // TODO NullException 해결해야함
            eCon.health -= damage;
            DestroyBullet();
            Debug.Log("부딪히나?");
        }
    }

    public void DestroyBullet()
    {
        // transform.SetParent(null);
        BulletPool.ReturnObject(this);
    }
}
