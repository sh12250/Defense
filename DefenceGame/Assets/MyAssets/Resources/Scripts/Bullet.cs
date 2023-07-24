using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    private Vector3 direction;

    void Update()
    {
        transform.Translate(0f, 0.1f, 0f);
    }

    public void SetDamage(float damage_)
    {
        damage = damage_;
    }

    public void Shoot(Vector3 direction_)
    {
        this.direction = direction_;
        transform.up = direction_.normalized;
        Invoke("DestroyBullet", 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
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
