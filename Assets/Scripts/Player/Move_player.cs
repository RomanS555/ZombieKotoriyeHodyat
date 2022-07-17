using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_player : MonoBehaviour
{
    [SerializeField] private float decceleration;
    [SerializeField] private float moveSpeed; 
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpStrengh;
    [SerializeField] bool isGround;
    private Player_values PV;

    [SerializeField] private Vector3 velocity;
    
    private Rigidbody rb;
    private Animator an;
    void Start()
    {
        PV = GetComponent<Player_values>();
        rb = GetComponent<Rigidbody>();
        an = transform.GetChild(0).GetChild(0).GetComponent<Animator>();

    }

 
    void Update()
    {
        float axeX = Input.GetAxis("Horizontal");
        float axeZ = Input.GetAxis("Vertical");
        if(Mathf.Abs(rb.velocity.x)+Mathf.Abs(rb.velocity.z) < maxSpeed){
        rb.velocity += (transform.forward * axeZ + transform.right* axeX ) * Time.deltaTime * moveSpeed;
        }else {
            rb.velocity = new Vector3(Mathf.Lerp(rb.velocity.x,0,decceleration*Time.deltaTime),rb.velocity.y,Mathf.Lerp(rb.velocity.z,0,decceleration*Time.deltaTime));
        }
        if(Mathf.Abs(axeX) + Mathf.Abs(axeZ) == 0){
             rb.velocity = new Vector3(Mathf.Lerp(rb.velocity.x,0,decceleration*Time.deltaTime),rb.velocity.y,Mathf.Lerp(rb.velocity.z,0,decceleration*Time.deltaTime));
        }
        an.SetBool("Moved",(Mathf.Abs(axeX) + Mathf.Abs(axeZ) != 0 && isGround));
       
        if(Input.GetKeyDown(KeyCode.Space) && isGround){
            rb.velocity += transform.up * jumpStrengh;
            isGround = false;
        }
        
       
        
    }
    private void OnTriggerStay(Collider other) {
        isGround = true;
       
    }
    private void OnTriggerEnter(Collider other) {        
        if(-rb.velocity.y > 5){
            PV.HPoperation(-rb.velocity.y*2);
        }
    }
    private void OnTriggerExit(Collider other) {
        isGround = false;
    }

    
   
}
