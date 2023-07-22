using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    private Vector2 direction;

    void Update()
    {
        transform.Translate(direction);
    }

    public void Shoot(Vector3 direction)
    {
        this.direction = direction;
        transform.up = direction;
        Invoke("DestroyBullet", 5f);
    }

    public void DestroyBullet()
    {
        BulletPool.ReturnObject(this);
    }

}
