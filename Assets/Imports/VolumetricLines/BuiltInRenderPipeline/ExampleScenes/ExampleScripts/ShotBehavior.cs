using UnityEngine;

public class ShotBehavior : MonoBehaviour
{
    private Vector3 m_target;
    public float speed;

    void Update()
    {
        // transform.position += transform.forward * Time.deltaTime * 300f;// The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        if (m_target != null)
        {
            if (transform.position == m_target)
            {
                Destroy(gameObject);
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
            // 
        }
    }

    public void setTarget(Vector3 target)
    {
        m_target = target;
    }

    public void shotToVoid()
    {
        transform.position += transform.forward * Time.deltaTime * 300f;
        
    } 
}