using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTestClass : MonoBehaviour
{
    public int diem { get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void suadiem(int d)
    {
        diem = d;
    }
    public int xemdiem()
    {
        return diem;
    }

}
