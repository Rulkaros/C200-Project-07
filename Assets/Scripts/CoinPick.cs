using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinValue = 1;

    [Header("Sound")]
    public AudioClip coinSfx;       // 拖 Coin.wav 到这里
    public float sfxVolume = 1f;    // 音量，0~1

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 加金币
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.AddCoin(coinValue);
            }

            // 播放音效
            if (coinSfx != null && Camera.main != null)
            {
                AudioSource.PlayClipAtPoint(
                    coinSfx,
                    Camera.main.transform.position,
                    sfxVolume
                );
            }

            // 销毁金币
            Destroy(gameObject);
        }
    }
}