using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public static GameManager instance;
    public GameObject[] enemies;

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
}
