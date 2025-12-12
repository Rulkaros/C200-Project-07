using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全局世界控制：一键在白天/黑夜之间切换，控制：
//// - Day/Night 物体显示
/// - 背景图片 / 颜色
/// - 相机背景颜色
/// - 切换音效
/// </summary>
public class World : MonoBehaviour
{
    // 单例，方便其他脚本读取当前是白天还是黑夜：World.Instance.IsDay
    public static World Instance { get; private set; }

    [Header("Input")]
    [Tooltip("切换白天/夜晚的按键")]
    [SerializeField] private KeyCode switchKey = KeyCode.Space;

    [Header("State")]
    [Tooltip("游戏开始时是否为白天")]
    [SerializeField] private bool startInDay = true;
    public bool IsDay { get; private set; }

    [Header("World Objects")]
    [Tooltip("只在白天显示/生效的物体（白天障碍、平台等）")]
    [SerializeField] private List<GameObject> dayObjects = new List<GameObject>();

    [Tooltip("只在夜晚显示/生效的物体（夜晚障碍、平台等）")]
    [SerializeField] private List<GameObject> nightObjects = new List<GameObject>();

    [Header("Visuals (Optional)")]
    [Tooltip("背景的大 SpriteRenderer（比如 Background 物体）")]
    [SerializeField] private SpriteRenderer backgroundRenderer;

    [Tooltip("白天时的背景图片（可选，不设置就不换图）")]
    [SerializeField] private Sprite dayBackground;

    [Tooltip("夜晚时的背景图片（可选，不设置就不换图）")]
    [SerializeField] private Sprite nightBackground;

    [Tooltip("白天背景颜色")]
    [SerializeField] private Color dayBackgroundColor = new Color(0.6f, 0.8f, 1f);

    [Tooltip("夜晚背景颜色")]
    [SerializeField] private Color nightBackgroundColor = new Color(0.05f, 0.05f, 0.15f);

    [Header("Audio (Optional)")]
    [Tooltip("切换世界时播放的音效（可选）")]
    [SerializeField] private AudioSource switchSfx;

    private Camera mainCamera;

    // ------------------- 生命周期 -------------------

    private void Awake()
    {
        // 简单单例：场景里如果已经有一个 World，就销毁多出来的
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        mainCamera = Camera.main;
    }

    private void Start()
    {
        // 初始化白天/夜晚状态
        IsDay = startInDay;
        ApplyWorldState();
    }

    private void Update()
    {
        // 一键切换：按下指定按键
        if (Input.GetKeyDown(switchKey))
        {
            ToggleWorld();
        }
    }

    // ------------------- 对外接口 -------------------

    /// <summary>
    /// 切换白天/夜晚
    /// </summary>
    public void ToggleWorld()
    {
        IsDay = !IsDay;
        ApplyWorldState();

        // 播放切换音效
        if (switchSfx != null)
        {
            switchSfx.Play();
        }
    }

    // ------------------- 内部逻辑 -------------------

    /// <summary>
    /// 根据 IsDay 更新：Day/Night 物体、背景图片/颜色、相机颜色
    /// </summary>
    private void ApplyWorldState()
    {
        // 1. 控制 Day 物体：白天启用，夜晚关闭
        foreach (GameObject obj in dayObjects)
        {
            if (obj != null)
                obj.SetActive(IsDay);
        }

        // 2. 控制 Night 物体：夜晚启用，白天关闭
        foreach (GameObject obj in nightObjects)
        {
            if (obj != null)
                obj.SetActive(!IsDay);
        }

        // 3. 切换背景图片（如果设置了的话）
        if (backgroundRenderer != null)
        {
            if (IsDay && dayBackground != null)
            {
                backgroundRenderer.sprite = dayBackground;
            }
            else if (!IsDay && nightBackground != null)
            {
                backgroundRenderer.sprite = nightBackground;
            }

            // 同时切换背景颜色
            backgroundRenderer.color = IsDay ? dayBackgroundColor : nightBackgroundColor;
        }

        // 4. 相机背景颜色（2D 场景也可以让边缘跟着变色）
        if (mainCamera != null)
        {
            mainCamera.backgroundColor = IsDay ? dayBackgroundColor : nightBackgroundColor;
        }
    }

#if UNITY_EDITOR
    // 右键组件菜单里可以在编辑器里一键切换世界，方便调试
    [ContextMenu("Toggle World (Editor)")]
    private void ToggleWorldInEditor()
    {
        ToggleWorld();
    }
#endif
}
