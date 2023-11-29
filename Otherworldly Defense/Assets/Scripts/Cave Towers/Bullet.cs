using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    float vMoveSpeed = 15000f;
    Enemy enemy;

    bool hasHitEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -(transform.up * vMoveSpeed) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if((other.tag == "Enemy" || other.tag == "Boss") && !hasHitEnemy) {
            hasHitEnemy = true;
            other.GetComponent<Enemy>().DamageEnemy(50);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
