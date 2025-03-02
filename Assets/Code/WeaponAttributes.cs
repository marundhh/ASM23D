using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttributes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AttributesManager atm = GetComponentInParent<AttributesManager>(); // Lấy AttributesManager từ cha gần nhất
        AttributesManager otherAttributes = other.GetComponent<AttributesManager>(); // Lấy AttributesManager của mục tiêu

        if (atm == null)
        {
            Debug.LogWarning("WeaponAttributes: Không tìm thấy AttributesManager trên vũ khí hoặc cha của nó.");
            return;
        }

        if (otherAttributes == null)
        {
            Debug.LogWarning("WeaponAttributes: Đối tượng bị va chạm không có AttributesManager.");
            return;
        }

        otherAttributes.TakeDamage(atm.attack);
    }
}
