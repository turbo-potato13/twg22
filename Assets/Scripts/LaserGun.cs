using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public float damage = 35f;
    public float range = 100f;
    public Camera FPSCamera;
    public GameObject impactEffect;
    public float impactForce = 30f;

    public float shootRate;
    private float shotRateTimeStamp;
    public GameObject shotPrefab;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
            if (Time.time > shotRateTimeStamp)
            {
                shotRateTimeStamp = Time.time + shootRate;
            }
        }
    }

    private void shoot()
    {
        RaycastHit hit;

        GameObject laser = Instantiate(shotPrefab, transform.position, shotPrefab.transform.rotation);
        ShotBehavior shotBehavior = laser.GetComponent<ShotBehavior>();
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range))
        {
            shotBehavior.setTarget(hit.point);
            Destroy(laser, 1f);
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takeDamage(damage);
                Destroy(laser);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 0.5f);
        }
    }
}