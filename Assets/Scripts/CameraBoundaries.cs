using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    Camera cam;
    float depth = 10.0f; // 从摄像机到Mars预期活动平面的深度

    void Start()
    {
        cam = Camera.main; // 获取主摄像机
    }

    // 获取在特定深度处摄像机视野的边界
    public Vector2 GetViewportBoundsAtDepth(float depth)
    {
        if (cam.orthographic)
        {
            float height = 2 * cam.orthographicSize;
            float width = height * cam.aspect;
            return new Vector2(width, height);
        }
        else
        {
            float height = 2.0f * depth * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
            float width = height * cam.aspect;
            return new Vector2(width, height);
        }
    }

    // 每帧更新，仅用于测试
    void Update()
    {
        // Vector2 bounds = GetViewportBoundsAtDepth(depth);
        // Debug.Log($"Width: {bounds.x}, Height: {bounds.y}");
    }
}
