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
    [SerializeField]private GameObject target;
    [SerializeField]private GameObject ragdoll;

   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _attackCooldown = attackCooldown;
        an = transform.GetChild(0).GetComponent<Animator>();
    }
    private void FixedUpdate() {
        if(HP <= 0){
            var d = Instantiate(ragdoll,transform.position,transform.GetChild(0).rotation);
            d.transform.GetChild(0).GetChild(0).GetComponent<Rigidbody>().AddForce(-transform.forward*400);
            
            Destroy(gameObject);
        }
        an.SetBool("isWalking",agent.velocity.magnitude != 0);
        Player_values[] players = FindObjectsOfType<Player_values>();
        float _mindistance = distanceOfView;
        for(int i = 0; i < players.Length; i++){
            GameObject player = players[i].gameObject;
            RaycastHit hit;
            if(Vector3.Distance(transform.GetChild(1).position,player.transform.position) <= _mindistance && Physics.Raycast(transform.GetChild(1).position,player.transform.position-transform.GetChild(1).position,out hit,distanceOfView ) && hit.transform.gameObject == player){
                _mindistance = Vector3.Distance(transform.GetChild(1).position,player.transform.position);
                target = player;
            }
            
        }
        if(target != null){
            GameObject player = target;
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
                            

                        }
                                
                 }
             }
        }
        
    }
}
    

