using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI coins;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: 0";
        coins.text = "Coins: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateScore(int score)
    {
        this.score.text = "Score: " + score;
    }
    
    public void UpdateCoins(int coins)
    {
        this.coins.text = "Coins: " + coins;
    }
    
    public void InitialMenu()
    {
        SceneManager.LoadScene("InitialMenuScene", LoadSceneMode.Single);
    }
}
