using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] int enemyMaxHealth = 100;
    private int enemyHealth;
    public HealthbarBehavior healthBar;

    bool hasDied = false;
    Stats stats;
    bool hasEscaped = false;

    void Start() {
        enemyHealth = enemyMaxHealth;
        healthBar.SetHealth(enemyHealth, enemyMaxHealth);
        stats = FindObjectOfType<Stats>();
    }

    void Update() {
        if(enemyHealth <= 0 && hasDied == false) {
            hasDied = true;
            stats.money += 3;
            stats.enemiesTillBoss -= 1;
            if(gameObject.tag == "Boss") {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

                int nextSceneIndex = currentSceneIndex + 1;
                SceneManager.LoadScene(nextSceneIndex);
            }
            Destroy(gameObject);
        }
    }

    public int GetEnemyHealth() {
        return enemyHealth;
    }

    public void DamageEnemy(int damage) {
        enemyHealth -= damage;
        healthBar.SetHealth(enemyHealth, enemyMaxHealth);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Escape" && !hasEscaped) {
            hasEscaped = true;
            if(gameObject.tag == "Enemy") {
                stats.lives -= 1;
                stats.enemiesTillBoss -= 1;
            }
            else if(gameObject.tag == "Boss") {
                stats.lives -= 10;
                // Initiate Loss Screen
            }
        }
    }
}
