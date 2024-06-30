using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TextMeshProUGUI CoinText, coinTotalText;
    public int SetGameCoin;
    public int SetComboCoin;
    public SpawnObstacle spawnObstacle;
    public bool GameOverBool;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        UpdateCoinText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        CoinText.text = "Game Coins: " + GlobalVar.GameCoin.ToString();
        coinTotalText.text = "Total Coins: " + GlobalVar.Coin.ToString();
        GlobalVar.LoadCoinTotal();
    }

    public void GameOver(){
        spawnObstacle.StopSpawning();
        GameOverBool = true;
    }
}
