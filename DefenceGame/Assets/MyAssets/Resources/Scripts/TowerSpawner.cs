using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject laserTowerPrefab;
    // public GameObject ricochetTowerPrefab;
    public GameObject towerTileMap;

    public LayerMask layerMask; // 감지할 레이어 마스크

    void Update()
    {
        // 마우스 위치를 화면 좌표에서 월드 좌표로 변환
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 레이캐스트 시작점
        Vector2 origin = new Vector2(mousePos.x, mousePos.y);

        // 레이캐스트 방향
        Vector2 direction = Vector2.zero;

        // 레이캐스트 실행
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity, layerMask);

        TowerButton tBtn = FindObjectOfType<TowerButton>();
        // 콜라이더 감지 여부 확인
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
