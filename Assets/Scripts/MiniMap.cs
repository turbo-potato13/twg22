using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        //Поворот камеры за персонажем
        // transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y + 180, 0f);
    }
}