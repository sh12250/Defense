using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;

    void Update()
    {
        transform.Translate(direction);
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
