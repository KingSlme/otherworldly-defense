using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHellTower1 : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] GameObject hellTowerPad;
    Stats stats;

    void Start() {
        stats = FindObjectOfType<Stats>();
    }

    IEnumerator purchaseTower() {
        Instantiate(tower, hellTowerPad.transform.position, hellTowerPad.transform.rotation);
        yield return new WaitForSecondsRealtime(.1f);
        Destroy(hellTowerPad);
    }
    
    void OnMouseDown() {
        if(stats.money >= 25) {
            stats.money -= 25;
            StartCoroutine(purchaseTower());
        }
    }
}
