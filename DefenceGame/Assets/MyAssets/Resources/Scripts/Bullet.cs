using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    private Vector3 direction;

    void Update()
    {
        transform.Translate(direction);
    }

    public void SetDamage(float damage_)
    {
        damage = damage_;
    }

    public void Shoot(Vector3 direction)
    {
        this.direction = direction;
        //transform.up = direction;
        Invoke("DestroyBullet", 0.5f);
    }

    public void DestroyBullet()
    {
        BulletPool.ReturnObject(this);
    }

}
