using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot4 : MonoBehaviour
{
    TowerRotation towerRotation;
    [SerializeField] Transform gun;
    //[SerializeField] GameObject bullet;
    GameObject bullet;

    bool alreadyFired = false;

    [SerializeField] AudioClip SFX;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GameObject.Find("Projectile Beam of Light");
        towerRotation = GetComponent<TowerRotation>();
    }

    IEnumerator Fire() {
        alreadyFired = true;
        yield return new WaitForSecondsRealtime(5f);
        AudioSource.PlayClipAtPoint(SFX, Camera.main.transform.position, 0.1f);
        Instantiate(bullet, gun.position, transform.rotation);
        alreadyFired = false;
    }

    void Update()
    {
        if(towerRotation.enemiesInRange.Count > 0) {
            if(!alreadyFired) {
                StartCoroutine(Fire());
            }
        }
    }
}
