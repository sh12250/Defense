using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public GameObject towerSpritePrefab;
    public bool isSpriteExist;

    private void Start()
    {
        isSpriteExist = false;
    }

    private void Update()
    {

    }

    public void CreateLaserTower()
    {
        if (isSpriteExist == true)
        {
            return;
        }

        if (GameManager.instance.gold + FindObjectOfType<TowerSpawner>().laserPrice >= 0)
        {
            isSpriteExist = true;
            GameObject towerSprite;
            towerSprite = Instantiate(towerSpritePrefab, Input.mousePosition, Quaternion.identity);
            TowerSpawner tSpawner = FindAnyObjectByType<TowerSpawner>();
            tSpawner.followMouseObj = towerSprite;
        }
    }

    public void CreateRicochetTower()
    {
        if (isSpriteExist == true)
        {
            return;
        }

        if (GameManager.instance.gold + FindObjectOfType<TowerSpawner>().ricochetPrice >= 0)
        {
            isSpriteExist = true;
            GameObject towerSprite;
            towerSprite = Instantiate(towerSpritePrefab, Input.mousePosition, Quaternion.identity);
            TowerSpawner tSpawner = FindAnyObjectByType<TowerSpawner>();
            tSpawner.followMouseObj = towerSprite;
        }
    }
}
