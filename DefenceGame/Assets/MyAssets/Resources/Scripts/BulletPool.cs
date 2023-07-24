using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    [SerializeField]
    private GameObject bulletPrefab;

    Queue<Bullet> bulletQueue = new Queue<Bullet>();

    private void Awake()
    {
        Instance = this;

        Initialize(100);
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            bulletQueue.Enqueue(CreateNewObject());
        }
    }

    private Bullet CreateNewObject()
    {
        Bullet newObj = Instantiate(bulletPrefab).GetComponent<Bullet>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static Bullet GetObject()
    {
        if (Instance.bulletQueue.Count > 0)
        {
            Bullet obj = Instance.bulletQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            Bullet newObj = Instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(Bullet obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.bulletQueue.Enqueue(obj);
    }
}
