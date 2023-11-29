using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHeavenTower1 : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] GameObject heavenTowerPad;
    Stats stats;

    void Start() {
        stats = FindObjectOfType<Stats>();
    }

    IEnumerator purchaseTower() {
        Instantiate(tower, heavenTowerPad.transform.position, heavenTowerPad.transform.rotation);
        yield return new WaitForSecondsRealtime(.1f);
        Destroy(heavenTowerPad);
    }
    
    void OnMouseDown() {
        if(stats.money >= 25) {
            stats.money -= 25;
            StartCoroutine(purchaseTower());
        }
    }
}
