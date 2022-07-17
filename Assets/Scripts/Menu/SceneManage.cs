using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void GoTo(string scen){
        SceneManager.LoadScene(scen);
    }
}
