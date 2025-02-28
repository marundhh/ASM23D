/*using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cần cài Layer của Player bơi thì nó mới có Animation
//Lấy Vector 3 - tăng giảm y (theo chiều dọc)

public class PlayerController : MonoBehaviour
{
    // Swim
    public bool isSwimming;
    public bool isUnderWater;

    private float defaultExtraGravity;

    private float currentSwimDepth = 3.95f; // Lưu trữ độ sâu hiện tại
    private float maxSwimDepth = 3.95f; // biến độ sâu tối đa khi ở nước 

    private Vector3 playerVelocity;

    private void Start()
    {
        defaultExtraGravity = thirdPersonMotor.extraGravity;

        playerVelocity = transform.position;
    }

    private void Update()
    {
        if (isSwimming)
        {
            if (isUnderWater)
            {
                Vector3 currentPosition = transform.position;

                // Nhấn chuột phải để giảm vị trí y
                if (Input.GetMouseButton(0)) // 1 là chuột phải
                {
                    currentSwimDepth = Mathf.Max(currentSwimDepth - 0.95f * Time.deltaTime, 0.3686f); // vd: 0.3686f chỉnh độ sâu nhất có thể lặn tới
                }

                // Nhấn chuột trái để tăng vị trí y
                if (Input.GetMouseButton(1)) // 0 là chuột trái
                {
                    currentSwimDepth = Mathf.Min(currentSwimDepth + 0.95f * Time.deltaTime, maxSwimDepth);
                }

                // Cập nhật vị trí y theo currentSwimDepth
                currentPosition.y = currentSwimDepth;

                transform.position = currentPosition;
            }
            else
            {
                // Đặt vận tốc y về 0 khi bơi trên mặt nước
                playerVelocity.y = 0;
            }
        }
        else
        {

        }
    }
}*/
