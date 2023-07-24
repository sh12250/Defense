using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public static EnemyStatus instance;

    public int Level { get; private set; }
    public float HealthMax { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("EnemyStatus가 너무 많습니다");
        }

        Level = 1;
        HealthMax = 4;
    }

    public void LevelUp()
    {
        Level += 1;
        HealthMax *= 1.1f;
    }
}
