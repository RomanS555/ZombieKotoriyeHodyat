using UnityEngine;
using UnityEngine.AI;

public class AIZombie : MonoBehaviour
{
    public int HP;
    [SerializeField] private float minDistance;
    [SerializeField] private float distanceOfView;
    private NavMeshAgent agent;
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate() {
        
    }
    private void OnTriggerStay(Collider other) {
        if(other.GetComponent<Move_player>()){
            GameObject player = other.gameObject;
            RaycastHit hit;
            if(Physics.Raycast(transform.GetChild(0).position,player.transform.position-transform.GetChild(0).position,out hit,distanceOfView ) && hit.transform.gameObject == player){
            
            agent.SetDestination(player.transform.position);
            }
            if(Vector3.Distance(transform.position,player.transform.position) <= minDistance){
                agent.isStopped = true;
            }else{agent.isStopped = false;}
        }
    }
}
