using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    float moveSpeed = 10f;
 
 void Start() {

 }
 
 void Update() {

        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
 }
}
