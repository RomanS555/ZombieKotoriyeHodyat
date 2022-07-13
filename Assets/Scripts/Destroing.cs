using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroing : MonoBehaviour
{
    private Rigidbody rb;
    public int HP = 4;
    private void FixedUpdate() {
        if(HP <= 0){
            Destroy(gameObject);
        }
    }
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    
}
