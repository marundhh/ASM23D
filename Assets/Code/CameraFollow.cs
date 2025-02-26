using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // Player hiện tại
    public Vector3 offset = new Vector3(0, 5, -10); // Khoảng cách camera

    void LateUpdate()
    {
        if (target != null)
            transform.position = target.position + offset;
    }
}
