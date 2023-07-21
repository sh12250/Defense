using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> enemies;

    public GameObject[] attackLine1 = default;
    public GameObject[] attackLine2 = default;

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("���� �Ŵ����� �ʹ� �����ϴ�");
        }
    }

    public void AddEnemyInEnemies(GameObject enemy_)
    {
        enemies.Add(enemy_);
    }
}
