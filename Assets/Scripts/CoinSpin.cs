using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    [Header("Rotation")]
    public float rotateSpeed = 180f;      // 每秒旋转角度（度）

    [Header("Bob (Up & Down)")]
    public float bobAmplitude = 0.1f;     // 上下浮动的高度
    public float bobFrequency = 2f;       // 浮动速度（频率）

    private Vector3 startPos;

    private void Start()
    {
        // 记录初始
        startPos = transform.position;
    }

    private void Update()
    {
        // 1. 绕 Z 轴旋转
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

        // 2. 上下浮动
        float newY = startPos.y + Mathf.Sin(Time.time * bobFrequency) * bobAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}