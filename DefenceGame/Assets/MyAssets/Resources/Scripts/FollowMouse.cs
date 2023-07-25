using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera;
    public bool isOnBase;

    private void Awake()
    {
        mainCamera = Camera.main;
        isOnBase = false;
    }

    private void Update()
    {
        if (isOnBase == false)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            transform.position = mainCamera.ScreenToWorldPoint(position);

            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
