using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotateSpeed = 60.0f; // 每秒旋转的度数

    // Update is called once per frame
    void Update()
    {
        // 旋转物体
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}