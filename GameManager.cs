using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int xpCount = 0;
    public int zexpCount = 0;

    public TextMeshProUGUI xpText;
    public TextMeshProUGUI zexpText;

    public GameObject xpCoinPrefab;
    public GameObject zexpCoinPrefab;

    private struct CoinData
    {
        public Vector3 position;
        public CoinType type;
    }

    private List<CoinData> initialCoinData = new List<CoinData>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        foreach (GameObject coin in coins)
        {
            Coin coinScript = coin.GetComponent<Coin>();
            if (coinScript != null)
            {
                CoinData data = new CoinData
                {
                    position = coin.transform.position,
                    type = coinScript.coinType
                };

                initialCoinData.Add(data);
            }

            Destroy(coin);
        }

        SpawnAllCoins();
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            ResetGame();
        }
    }

    public void CollectCoin(CoinType type)
    {
        if (type == CoinType.XP)
        {
            xpCount++;
            FindObjectOfType<PlayerXp>().AddXP(2);
        }
        else
        {
            zexpCount++;
            FindObjectOfType<PlayerXp>().AddZEXP(5);
        }

        UpdateUI();
    }



    public void ResetGame()
    {
        xpCount = 0;
        zexpCount = 0;
        UpdateUI();

        foreach (GameObject coin in GameObject.FindGameObjectsWithTag("Coin"))
        {
            Destroy(coin);
        }

        SpawnAllCoins();
        Debug.Log("ریست بازی فراخوانی شد!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SpawnAllCoins()
    {
        foreach (CoinData data in initialCoinData)
        {
            GameObject prefab = data.type == CoinType.XP ? xpCoinPrefab : zexpCoinPrefab;
            Instantiate(prefab, data.position, Quaternion.identity);
        }
    }

    private void UpdateUI()
    {
        xpText.text = "XP: " + xpCount;
        zexpText.text = "ZEXP: " + zexpCount;
    }
}
