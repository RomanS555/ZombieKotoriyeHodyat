using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public void ChoosePlaymode(){
        transform.GetChild(4).gameObject.SetActive(!transform.GetChild(4).gameObject.activeSelf);
    }
    public void EnableOptions(){
        transform.GetChild(5).gameObject.SetActive(!transform.GetChild(5).gameObject.activeSelf);
    }
    public void Graphics(int g){
        QualitySettings.SetQualityLevel(g);
    }
    private void FixedUpdate(){
        Options.sensetive = transform.GetChild(5).GetChild(1).GetComponent<Slider>().value * 1000;
    }
    private void Start() {
        Cursor.lockState = CursorLockMode.None;
    }


}
