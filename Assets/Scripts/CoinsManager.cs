using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    public static CoinsManager Instance;

    public TextMeshProUGUI scoreText;

    public int currentCoins;
    public int maxCoins;

    void Awake(){
        Instance = this;
    }

    void Update(){
        scoreText.text = "COINS: " + currentCoins.ToString();
    }

    public void SetCoins(int coins){
        currentCoins = coins;
    }

    public void AddCoins(int coins){
        currentCoins += coins;
        if(currentCoins > maxCoins) currentCoins = maxCoins;
    }

    public bool RemoveCoins(int coins){
        if((currentCoins-coins) < 0) return false;
        else {
            currentCoins -= coins;
            return true;
        }
    }
}
