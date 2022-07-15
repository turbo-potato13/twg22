using System;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public float damage = 35f;
    public float range = 100f;
    public Camera FPSCamera;

    public float shootRate;
    private float shotRateTimeStamp;
    public GameObject shotPrefab;


    // public void Awake()
    // {
    //     throw new NotImplementedException();
    // }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
            
        }
    }

    private void shoot()
    {
        shotPrefab.GetComponent<ShotBehavior>().damage = damage;
        GameObject laser = Instantiate(shotPrefab, transform.parent.position, transform.parent.rotation);
    }
}