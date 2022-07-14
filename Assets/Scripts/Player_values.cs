using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_values : MonoBehaviour
{
    public float HP;
    [SerializeField] Image hpBar;

    private void FixedUpdate() {
        hpBar.rectTransform.sizeDelta = Vector3.right * HP *2 + Vector3.up*hpBar.rectTransform.sizeDelta.y;
        if(HP<=0){
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void HPoperation(float hp){
        HP -= hp;
    }
}
