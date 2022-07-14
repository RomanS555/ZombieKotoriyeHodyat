using UnityEngine;
using UnityEngine.AI;

public class AIZombie : MonoBehaviour
{
    public int HP;
    [SerializeField] private float AttackDistance = 2;
    [SerializeField] private float distanceOfView;
    [SerializeField] private float damage;
    [SerializeField] private float attackCooldown = 2;
    [SerializeField]private float _attackCooldown = 2;
    private NavMeshAgent agent;
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _attackCooldown = attackCooldown;
    }
    private void FixedUpdate() {
        if(HP <= 0){
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.GetComponent<Move_player>()){
            GameObject player = other.gameObject;
            RaycastHit hit;
            if(Physics.Raycast(transform.GetChild(0).position,player.transform.position-transform.GetChild(0).position,out hit,distanceOfView ) && hit.transform.gameObject == player){
            
            agent.SetDestination(player.transform.position);
             if(Vector3.Distance(transform.GetChild(0).position,player.transform.position) <= AttackDistance){
                        if(_attackCooldown > 0){
                            _attackCooldown -= Time.deltaTime;
                        }else {
                            player.GetComponent<Player_values>().HPoperation(damage);
                            _attackCooldown = attackCooldown;
                        }
                                
                 }
             }
         }
           
            
        }
    }

