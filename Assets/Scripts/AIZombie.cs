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

    private Animator an;
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _attackCooldown = attackCooldown;
        an = transform.GetChild(0).GetComponent<Animator>();
    }
    private void FixedUpdate() {
        if(HP <= 0){
            Destroy(gameObject);
        }
        an.SetBool("isWalking",agent.velocity.magnitude != 0);
    }
    private void OnTriggerStay(Collider other) {
        if(other.GetComponent<Move_player>()){
            GameObject player = other.gameObject;
            RaycastHit hit;
            if(Physics.Raycast(transform.GetChild(1).position,player.transform.position-transform.GetChild(1).position,out hit,distanceOfView ) && hit.transform.gameObject == player){
            
            agent.SetDestination(player.transform.position);
             if(Vector3.Distance(transform.GetChild(1).position,player.transform.position) <= AttackDistance){
                        if(_attackCooldown > 0){
                            _attackCooldown -= Time.deltaTime;
                            agent.isStopped = false;
                        }else {
                            player.GetComponent<Player_values>().HPoperation(damage);
                            _attackCooldown = attackCooldown;
                            an.SetTrigger("attack");
                            agent.isStopped = true;

                        }
                                
                 }else agent.isStopped = false;
             }
         }
           
            
        }
    }

