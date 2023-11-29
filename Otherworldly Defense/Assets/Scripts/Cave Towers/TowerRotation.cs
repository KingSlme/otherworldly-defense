using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotation : MonoBehaviour
{

    // EnemyRedo enemy;
    public GameObject currentTarget;

    float speed = 75f;
    float rotationModifier = 270f;


    public List<GameObject> enemiesInRange = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other) {
        // Add enemy to enemiesInRange list
        if(other.tag == "Enemy" || other.tag == "Boss") {
            enemiesInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        // Remove enemy from enemiesInRange list
        if(other.tag == "Enemy" || other.tag == "Boss") {
            enemiesInRange.Remove(other.gameObject);
        }
    }

    void GetCurrentTargetedEnemy() {
        // *Maybe do null check later
        currentTarget = enemiesInRange[0];
    }

    private void FixedUpdate() {
        if(enemiesInRange.Count > 0) {
            GetCurrentTargetedEnemy();
        }

        if(currentTarget != null) {
            Vector3 vectorToTarget = currentTarget.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }

    }
}
