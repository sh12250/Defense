using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower1 : MonoBehaviour
{
    public float damage { get; private set; }

    private void Start()
    {
        damage = 0.5f;
    }
}
