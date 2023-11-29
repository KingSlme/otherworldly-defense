using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{   
    // Lives decremented by 1 per enemy escaping
    public int lives = 10;
    // Money incrememented by 2 per kill
    public int money = 25;
    // Enemies Till Boss decremented for each killed and escaped enemy
    public int enemiesTillBoss = 100;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI enemiesTillBossText;

    void Start()
    {
        
    }


    void Update()
    {
        livesText.text = "Lives: " + lives;
        moneyText.text = "$" + money;
        enemiesTillBossText.text = "Enemies Till Boss Fight: " + enemiesTillBoss;
        if(lives <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
