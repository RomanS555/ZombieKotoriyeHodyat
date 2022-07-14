using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    private Camera cam;
    private WeaponPlayer wp;
    [SerializeField] private int[] damages;
    //[SerializeField] private string[] audios;
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Shoot(wp.weaponID-1);
        }
    }

    private void Start() {
        cam = Camera.main;
        wp = GetComponent<WeaponPlayer>();
    }
    public void Shoot(int id){
        RaycastHit hit;

        if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit)){
            if(hit.transform.GetComponent<AIZombie>()){
                hit.transform.GetComponent<AIZombie>().HP -= damages[id];
            }
        }
    }
}
