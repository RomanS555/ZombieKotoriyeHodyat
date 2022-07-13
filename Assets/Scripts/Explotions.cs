using UnityEngine.AI;
using UnityEngine;

public class Explotions : MonoBehaviour
{
    private ParticleSystem Expl;
    void Start()
    {
        Expl = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        if(!Expl.gameObject.activeSelf){
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.GetComponent<Destroing>()){
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<NavMeshObstacle>().carving = false;
            other.gameObject.GetComponent<Destroing>().HP -= 1;
        }
    }
}
