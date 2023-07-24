using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject map = default;
    public GameObject enemyPrefab = default;
    public GameObject[] enemies = default;
    public Vector3[] spawnPositions = default;

    public float time = default;
    public float spawnRate = 0.5f;
    public int spawnCount = 0;

    void Start()
    {
        SetSpawnPositions();
    }

    private void SetSpawnPositions()
    {
        spawnPositions = new Vector3[25];
        spawnPositions[0] = new Vector3(-8.25f, 4.25f, 0f);
        spawnPositions[1] = new Vector3(-7.75f, 4.25f, 0f);
        spawnPositions[2] = new Vector3(-7.25f, 4.25f, 0f);
        spawnPositions[3] = new Vector3(-6.75f, 4.25f, 0f);
        spawnPositions[4] = new Vector3(-6.25f, 4.25f, 0f);
        spawnPositions[5] = new Vector3(-8.25f, 3.75f, 0f);
        spawnPositions[6] = new Vector3(-7.75f, 3.75f, 0f);
        spawnPositions[7] = new Vector3(-7.25f, 3.75f, 0f);
        spawnPositions[8] = new Vector3(-6.75f, 3.75f, 0f);
        spawnPositions[9] = new Vector3(-6.25f, 3.75f, 0f);
        spawnPositions[10] = new Vector3(-8.25f, 3.25f, 0f);
        spawnPositions[11] = new Vector3(-7.75f, 3.25f, 0f);
        spawnPositions[12] = new Vector3(-7.25f, 3.25f, 0f);
        spawnPositions[13] = new Vector3(-6.75f, 3.25f, 0f);
        spawnPositions[14] = new Vector3(-6.25f, 3.25f, 0f);
        spawnPositions[15] = new Vector3(-8.25f, 2.75f, 0f);
        spawnPositions[16] = new Vector3(-7.75f, 2.75f, 0f);
        spawnPositions[17] = new Vector3(-7.25f, 2.75f, 0f);
        spawnPositions[18] = new Vector3(-6.75f, 2.75f, 0f);
        spawnPositions[19] = new Vector3(-6.25f, 2.75f, 0f);
        spawnPositions[20] = new Vector3(-8.25f, 2.25f, 0f);
        spawnPositions[21] = new Vector3(-7.75f, 2.25f, 0f);
        spawnPositions[22] = new Vector3(-7.25f, 2.25f, 0f);
        spawnPositions[23] = new Vector3(-6.75f, 2.25f, 0f);
        spawnPositions[24] = new Vector3(-6.25f, 2.25f, 0f);
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnRate)
        {
            time = 0;
            spawnCount += 1;

            int randIdx = Random.Range(0, 25);

            GameObject enemy = Instantiate(enemyPrefab, spawnPositions[randIdx], Quaternion.identity, map.transform);

            SetEnemyStatus(enemy);
            GameManager.instance.AddEnemyInEnemies(enemy);
        }

        if(spawnCount == 10)
        {
            spawnCount = 0;

            EnemyStatus.instance.LevelUp();
        }
    }

    private void SetEnemyStatus(GameObject enemy_)
    {
        EnemyController eCon = enemy_.GetComponent<EnemyController>();
        eCon.level = EnemyStatus.instance.Level;
        eCon.healthMax = EnemyStatus.instance.HealthMax;
        eCon.health = eCon.healthMax;
    }
}
