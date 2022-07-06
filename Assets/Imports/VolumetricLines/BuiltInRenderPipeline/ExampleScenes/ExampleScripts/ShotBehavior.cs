using UnityEngine;

public class ShotBehavior : MonoBehaviour
{
    private Vector3 m_target;
    public float speed;

    void Update()
    {
        // transform.rotation = new Quaternion(0, 0, 0 ,0);
        transform.position +=
            transform.forward * Time.deltaTime * 300f; // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        if (m_target != null)
        {
            if (transform.position == m_target)
            {
                Destroy(gameObject);
            }

            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
            Destroy(gameObject, 1f);
        }
    }

    public void setTarget(Vector3 target)
    {
        m_target = target;
    }
}