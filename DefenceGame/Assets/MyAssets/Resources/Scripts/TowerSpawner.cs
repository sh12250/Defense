using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject laserTowerPrefab;
    // public GameObject ricochetTowerPrefab;
    public GameObject towerTileMap;

    public LayerMask layerMask; // ������ ���̾� ����ũ

    void Update()
    {
        // ���콺 ��ġ�� ȭ�� ��ǥ���� ���� ��ǥ�� ��ȯ
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ����ĳ��Ʈ ������
        Vector2 origin = new Vector2(mousePos.x, mousePos.y);

        // ����ĳ��Ʈ ����
        Vector2 direction = Vector2.zero;

        // ����ĳ��Ʈ ����
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity, layerMask);

        TowerButton tBtn = FindObjectOfType<TowerButton>();
        // �ݶ��̴� ���� ���� Ȯ��
        if (tBtn.isSpriteExist == true)
        {
            if (hit.collider != null && hit.collider.tag == "TowerBase")
            {
                FollowMouse followMouse = FindObjectOfType<FollowMouse>();
                followMouse.enabled = false;

                followMouse.gameObject.transform.position = hit.collider.gameObject.transform.position;

                if (Input.GetMouseButtonDown(0))
                {
                    tBtn.isSpriteExist = false;
                    Destroy(followMouse.gameObject);

                    GameObject obj = Instantiate(laserTowerPrefab, hit.transform.position, Quaternion.identity, towerTileMap.transform);

                    hit.collider.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
            else
            {
                FollowMouse followMouse = FindObjectOfType<FollowMouse>();
                followMouse.enabled = true;
            }
        }
    }
}
