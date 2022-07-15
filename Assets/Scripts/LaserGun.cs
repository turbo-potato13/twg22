using System;
using DefaultNamespace;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public float damage = 35f;
    public float range = 100f;
    public Camera FPSCamera;

    public float shootRate;
    private float shotRateTimeStamp;
    public GameObject shotPrefab;
    public FirstPersonDog player;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonDog>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            player.putDischarge(0.3f);
            shoot();
            
        }
    }

    private void shoot()
    {
        shotPrefab.GetComponent<ShotBehavior>().damage = damage;
        GameObject laser = Instantiate(shotPrefab, transform.parent.position, transform.parent.rotation);
    }
}