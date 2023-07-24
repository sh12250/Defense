using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : MonoBehaviour
{
    public float Damage { get; private set; }
    public float ShootRate { get; private set; }

    private void Awake()
    {
        Damage = 5.0f;
        ShootRate = 0.01f;
    }

    private void Start()
    {

    }

    public void LevelUpTower()
    {
        Damage *= 2;
        ShootRate /= 2;
    }
}
