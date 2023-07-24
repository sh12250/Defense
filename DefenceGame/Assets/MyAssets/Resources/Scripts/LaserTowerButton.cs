using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTowerButton : MonoBehaviour
{
    public GameObject towerSprite;
    public GameObject tempSprite;

    private void Update()
    {
        if (tempSprite != null)
        {
            tempSprite.transform.position = Input.mousePosition;
        }
    }

    public void CreateRaserTower()
    {
        if (tempSprite == null)
        {
            tempSprite = Instantiate(towerSprite, Input.mousePosition, Quaternion.identity);
        }
    }
}
