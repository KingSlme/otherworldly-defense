using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCaveTower2 : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] GameObject caveTowerPad;
    Stats stats;

    void Start() {
        stats = FindObjectOfType<Stats>();
    }

    IEnumerator purchaseTower() {
        Instantiate(tower, caveTowerPad.transform.position, caveTowerPad.transform.rotation);
        yield return new WaitForSecondsRealtime(.1f);
        Destroy(caveTowerPad);
    }

    void OnMouseDown() {
        if(stats.money >= 15) {
            stats.money -= 15;
            StartCoroutine(purchaseTower());
        }
    }
}
