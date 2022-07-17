using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    [SerializeField] float maxAngle = 90f;
    float rotX = 0;
    
    Camera cam;
    
    void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0,Options.sensetive * Input.GetAxisRaw("Mouse X") * Time.deltaTime,0);
        
        rotX += Input.GetAxisRaw("Mouse Y") * Options.sensetive * Time.deltaTime;
        rotX = Mathf.Clamp(rotX,-maxAngle,maxAngle);
        cam.transform.localEulerAngles = new Vector3(-rotX,0,0);
    }
}
