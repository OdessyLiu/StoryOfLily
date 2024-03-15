using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public float sensitivity = 2.0f; // 鼠标灵敏度
    public float zoomSpeed = 2.0f;   // 缩放速度
    public float minZoomDistance = 2.0f; // 最小缩放距离
    public float maxZoomDistance = 10.0f; // 最大缩放距离

    void Update()
    {
        // 获取鼠标移动量
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 根据鼠标移动量调整摄像机旋转
        transform.Rotate(Vector3.up * mouseX * sensitivity, Space.World);
        transform.Rotate(Vector3.left * mouseY * sensitivity, Space.Self);

        // 获取鼠标滚轮输入
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        // 根据鼠标滚轮输入调整摄像机缩放
        float zoomDistance = transform.localPosition.z + scrollWheel * zoomSpeed;

        // 限制缩放距离在指定范围内
        zoomDistance = Mathf.Clamp(zoomDistance, -maxZoomDistance, -minZoomDistance);

        // 应用新的缩放距离
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, zoomDistance);
    }
}
