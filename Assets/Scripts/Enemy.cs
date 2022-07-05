using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP = 100;

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