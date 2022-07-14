using UnityEngine;

public class ShotBehavior : MonoBehaviour
{
    private Rigidbody rigidBody;

    public float speed = 300f;
    public float lifespan = 3f;
    public float damage;
    public GameObject impactEffect;
    public float impactForce = 30f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().takeDamage(damage);
        } else if (other.gameObject.tag == "Door" && other.isTrigger)
        {
            return;
        }
        GameObject impactGo = Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(impactGo, 2f);
        Destroy(gameObject);
    }

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Start()
    {
        rigidBody.AddForce(rigidBody.transform.forward * speed);
        Destroy(gameObject, lifespan);
    } 
}