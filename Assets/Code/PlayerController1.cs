using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direction;

    // Cho phép override trong test
    public virtual bool GetKey(KeyCode key) => Input.GetKey(key);

    void Update()
    {
        direction = Vector3.zero;

        if (GetKey(KeyCode.W)) direction += Vector3.forward;
        if (GetKey(KeyCode.S)) direction += Vector3.back;
        if (GetKey(KeyCode.A)) direction += Vector3.left;
        if (GetKey(KeyCode.D)) direction += Vector3.right;

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
