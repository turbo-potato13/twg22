using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP = 100;

    // private void Update()
    // {
    //     float x = transform.position.x;
    //     float z = transform.position.z;
    //     if (x < -84 || x > 33 || z > 48 || z < -60)
    //     {
    //         transform.position = new Vector3(-25.9699993f, 0f, 0f);
    //     }
    // }

    public void takeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Destroy(transform.gameObject);
    }

   
}