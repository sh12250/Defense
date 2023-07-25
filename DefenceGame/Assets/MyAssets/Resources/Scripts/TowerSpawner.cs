using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject laserTowerPrefab;
    public GameObject ricochetTowerPrefab;
    public GameObject towerTileMap;

    public GameObject laserTowerButton;
    public GameObject ricochetTowerButton;
    public GameObject followMouseObj;

    public int laserPrice;
    public int ricochetPrice;

    public int towerCnt;

    public LayerMask layerMask; // ������ ���̾� ����ũ

    private void Awake()
    {
        laserPrice = -75;
        ricochetPrice = -50;
        towerCnt = 0;
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);             // ���콺 ��ġ�� ȭ�� ��ǥ���� ���� ��ǥ�� ��ȯ
        Vector2 origin = new Vector2(mousePos.x, mousePos.y);                               // ����ĳ��Ʈ ������
        Vector2 direction = Vector2.zero;                                                   // ����ĳ��Ʈ ����
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity, layerMask); // ����ĳ��Ʈ ����

        // �ݶ��̴� ���� ���� Ȯ��
        if (laserTowerButton.GetComponent<TowerButton>().isSpriteExist == true || ricochetTowerButton.GetComponent<TowerButton>().isSpriteExist == true)
        {
            if (hit.collider != null && hit.collider.tag == "TowerBase")
            {
                FollowMouse followMouse = followMouseObj.GetComponent<FollowMouse>();
                followMouse.enabled = false;

                followMouseObj.transform.position = hit.collider.gameObject.transform.position;

                if (Input.GetMouseButtonDown(0))
                {
                    Destroy(followMouseObj);

                    if (laserTowerButton.GetComponent<TowerButton>().isSpriteExist == true)
                    {
                        towerCnt += 1;

                        laserTowerButton.GetComponent<TowerButton>().isSpriteExist = false;
                        Instantiate(laserTowerPrefab, hit.transform.position, Quaternion.identity, towerTileMap.transform);
                        GameManager.instance.AddGold(laserPrice);
                    }
                    if (ricochetTowerButton.GetComponent<TowerButton>().isSpriteExist == true)
                    {
                        towerCnt += 1;

                        ricochetTowerButton.GetComponent<TowerButton>().isSpriteExist = false;
                        Instantiate(ricochetTowerPrefab, hit.transform.position, Quaternion.identity, towerTileMap.transform);
                        GameManager.instance.AddGold(ricochetPrice);
                    }

                    hit.collider.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
            else
            {
                FollowMouse followMouse = FindObjectOfType<FollowMouse>();
                followMouse.enabled = true;
            }

            if(towerCnt > 3)
            {
                towerCnt -= 1;
                laserPrice = (int)(laserPrice * 1.2);
                ricochetPrice = (int)(ricochetPrice * 1.2);
            }
        }
    }
}
