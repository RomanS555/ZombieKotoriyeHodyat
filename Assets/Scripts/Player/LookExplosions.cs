using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookExplosions : MonoBehaviour
{
    private Camera cam;
    [SerializeField]private GameObject Explotion;
    private void Start() {
        cam = Camera.main;
    }
    void Update()
    {
        
         if(Input.GetMouseButtonDown(0)){
             Boom();
            
        }
    }
    void Boom(){
        RaycastHit hit;
        if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit)){
                 Instantiate(Explotion, hit.point, transform.rotation);
             }
    }
}
