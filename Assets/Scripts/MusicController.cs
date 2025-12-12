using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WorldMusicController : MonoBehaviour
{
    [Header("World Music Clips")]
    public AudioClip dayClip;
    public AudioClip nightClip;

    private AudioSource audioSource;
    private bool lastIsDay = true;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (World.Instance != null)
        {
            lastIsDay = World.Instance.IsDay;
        }

        PlayClipForState(lastIsDay);
    }

    private void Update()
    {
        if (World.Instance == null) return;

        // 检测 World 的 IsDay 是否发生变化
        bool currentIsDay = World.Instance.IsDay;
        if (currentIsDay != lastIsDay)
        {
            lastIsDay = currentIsDay;
            PlayClipForState(lastIsDay);
        }
    }

    private void PlayClipForState(bool isDay)
    {
        AudioClip target = isDay ? dayClip : nightClip;
        if (target == null) return;

        audioSource.Stop();
        audioSource.clip = target;
        audioSource.loop = true;
        audioSource.Play();
    }
}
