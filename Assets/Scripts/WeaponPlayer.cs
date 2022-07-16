using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : MonoBehaviour
{
    [Min(0)]public int weaponID;
    [Min(0)]public int weaponBackID;
    private Animator anim;
    private Transform weapons;
    private Camera cam;
    void Start()
    {
        anim = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        cam = Camera.main;
        weapons = transform.GetChild(0).GetChild(0).GetChild(2);
    }

    
    void Update()
    {
        anim.SetInteger("WeapChoose",weaponID);
        if(Input.GetAxis("Mouse ScrollWheel") != 0){
           int tre;
           tre = weaponID;
           weaponID = weaponBackID;
           weaponBackID = tre;
        }

        for(int i = 0; i < weapons.childCount; i++){
            
            if(weaponID-1 == i){
                weapons.GetChild(i).gameObject.SetActive(true);
            }else{weapons.GetChild(i).gameObject.SetActive(false);}
        }


        if(Input.GetKeyDown(KeyCode.E) && weaponID == 0){
            PickUpItem();
        }
    }

    private void PickUpItem(){
        RaycastHit hit;
        if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit,4)){
            if(hit.transform.gameObject.GetComponent<Item_info>()){
                if (hit.transform.gameObject.GetComponent<Item_info>().weapon){
                    weaponID = hit.transform.gameObject.GetComponent<Item_info>().ID;
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
