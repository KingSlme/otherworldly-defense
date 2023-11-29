using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveUIToggle : MonoBehaviour
{
    [SerializeField] GameObject CaveTowerPadUI;

    IEnumerator AddDelay() {
        yield return new WaitForSecondsRealtime(5f);
        CaveTowerPadUI.SetActive(false);
    }

    void OnMouseDown() {
        CaveTowerPadUI.SetActive(true);
        StartCoroutine(AddDelay());
    }

}
