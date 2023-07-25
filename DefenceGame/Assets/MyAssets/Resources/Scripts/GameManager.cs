using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> enemies;

    public GameObject[] attackLine1 = default;
    public GameObject[] attackLine2 = default;

    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text lifeText;
    public TMPro.TMP_Text goldText;
    public TMPro.TMP_Text levelText;

    public int score;
    public int life;
    public int gold;

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("게임 매니져가 너무 많습니다");
        }

        score = 0;
        life = 10;
        gold = 100;
    }

    public void AddEnemyInEnemies(GameObject enemy_)
    {
        enemies.Add(enemy_);
    }

    public void AddScore(int health_)
    {
        score += health_;
        scoreText.text = string.Format("Score : {0}", score);
    }

    public void SetLife()
    {
        life -= 1;
        lifeText.text = string.Format("Life : {0}", life);
    }

    public void AddGold(int addNum_)
    {
        gold += addNum_;
        goldText.text = string.Format("Gold : {0}", gold);
    }

    public void AddLevel(int level_)
    {
        levelText.text = string.Format("Level : {0}", level_);
    }
}
