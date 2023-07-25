using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfoUi : MonoBehaviour
{
    public Image healthBar;
    public GameObject target;
    private EnemyController eCon;
    private float temp;

    private void Start()
    {
    }

    private void Update()
    {
        if(eCon == null && target != null)
        {
            eCon = target.GetComponent<EnemyController>();
            temp = eCon.health;
            SetHealthBar();
        }

        if (eCon != null && temp != eCon.health)
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
