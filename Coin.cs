using UnityEngine;

public enum CoinType { XP, ZEXP }

public class Coin : MonoBehaviour
{
    public CoinType coinType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.CollectCoin(coinType);
            Destroy(gameObject);
        }
    }
}