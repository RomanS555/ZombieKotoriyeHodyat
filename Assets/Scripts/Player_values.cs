using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_values : MonoBehaviour
{
    public float HP;
    [SerializeField] Slider hpBar;

    private void FixedUpdate() {
        hpBar.value = HP;
        if(HP<=0){
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void HPoperation(float hp){
        HP -= hp;
    }
}
