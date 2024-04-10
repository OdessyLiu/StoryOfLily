using UnityEngine;

public class MarsBehavior : MonoBehaviour
{
    public float speed = 0.1f; // Mars移动到新位置的速度
    private Vector3 targetPosition; // Mars的目标位置
    private bool isMoving = false; // Mars是否正在移动到新位置

    void Start()
    {
       
    }

    void Update()
    {
        if (isMoving)
        {
            MoveTowardsTarget();
        }
        else
        {
            RotateMars();
            // 已移除SetNewTargetPosition的调用，Mars不再进行随机移动
        }
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            // Mars到达目标位置
            isMoving = false;
        }
    }

    void RotateMars()
    {
        transform.Rotate(0, -0.7f, 0, Space.Self);
    }

    void SetNewTargetPosition()
    {
        float randomX = Random.Range(-15f, 5f);
        float randomY = Random.Range(-2f, 2f);
        float randomZ = Random.Range(-2f, 10f);
        targetPosition = new Vector3(randomX, randomY, randomZ);
        
        isMoving = true; // 开始移动
    }

    public void SetInitialRightTargetPosition()
    {
        float initialX = transform.position.x + 5; // 确保这个值足够大，以让Mars向右飞
        float initialY = Random.Range(-2f, 2f);
        float initialZ = Random.Range(-2f, 10f);
        targetPosition = new Vector3(initialX, initialY, initialZ);

        isMoving = true; // 开始移动
    }
}
