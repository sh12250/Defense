using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        
    }

    void Update()
    {
        if(target != null)
        {
            transform.position = target.transform.position;
        }
        else 
        {
            //pass
        }
    }
}
