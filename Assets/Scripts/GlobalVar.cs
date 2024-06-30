using UnityEngine;

public class GlobalVar : MonoBehaviour
{
    // Static variable to store the coin count
    public static int Coin;
    public static int GameCoin;

    void Start()
    {
        LoadCoinTotal();
    }

    public static void SaveCoinTotal()
    {
        PlayerPrefs.SetInt("Coin", Coin);
        PlayerPrefs.Save();
    }

    public static void LoadCoinTotal()
    {
        // Default value is 0 if "coinTotal" key does not exist
        Coin = PlayerPrefs.GetInt("Coin");
    }

    public static void AddCoin(){
        Coin = Coin + GameManager.Instance.SetGameCoin;
        GameCoin = GameCoin + GameManager.Instance.SetGameCoin;
    }

    public static void AddComboCoin(){
        Coin = Coin + GameManager.Instance.SetComboCoin;
        GameCoin = GameCoin + GameManager.Instance.SetComboCoin;
    }
}