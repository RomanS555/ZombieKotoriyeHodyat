using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void ChoosePlaymode(){
        transform.GetChild(3).gameObject.SetActive(!transform.GetChild(3).gameObject.activeSelf);
    }
}
