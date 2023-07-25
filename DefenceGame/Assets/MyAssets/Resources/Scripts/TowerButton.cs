using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public GameObject towerSpritePrefab;
    public bool isSpriteExist;

    private int price;

    private void Start()
    {
        isSpriteExist = false;
        price = 50;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        Physics.Raycast(ray, out raycastHit);
    }

    public void CreateLaserTower()
    {
        if (isSpriteExist == true)
        {
            return;
        }

        isSpriteExist = true;
        GameObject towerSprite;
        towerSprite = Instantiate(towerSpritePrefab, Input.mousePosition, Quaternion.identity);
    }

    public void CreateRicochetTower()
    {
        if (isSpriteExist == true)
        {
            return;
        }

        isSpriteExist = true;
        GameObject towerSprite;
        towerSprite = Instantiate(towerSpritePrefab, Input.mousePosition, Quaternion.identity);
    }
}
