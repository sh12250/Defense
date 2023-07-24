using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfoUi : MonoBehaviour
{
    public Image healthBar;
    private EnemyController eCon;
    private float temp;

    private void Start()
    {
        eCon = gameObject.GetComponentInParent<EnemyController>();
        temp = eCon.health;
        SetHealthBar();
    }

    private void Update()
    {
        if (temp != eCon.health)
        {
            temp = eCon.health;
            SetHealthBar();
        }
    }

    public void SetHealthBar()
    {
        healthBar.fillAmount = eCon.health / eCon.healthMax;
    }
}
