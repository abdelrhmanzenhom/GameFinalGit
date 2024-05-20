using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public enum EnemyState
{
    CHASE,ATTACK
}

public class EnemyController : MonoBehaviour
{

    private Charanimation enemy_Anim;
    private NavMeshAgent navAgent;
    private Transform playerTarget;
    public float move_speed = 3.5f;
    public float attack_Distance = 1f;
    public float chasePlayerAfterAttackDistance = 1f;
    private float waitBeforeAttackTime = 2f;
    private float attackTimer;
    private EnemyState enemyState;
    public GameObject attackPoint;
    private ChracterSound sound;
    // Start is called before the first frame update

    void Awake()
    {
        enemy_Anim = GetComponent<Charanimation>();
        navAgent = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
        sound = GetComponentInChildren<ChracterSound>();

    }
    void Start()
    {
        enemyState = EnemyState.CHASE;
        attackTimer = waitBeforeAttackTime;
        
    }

    // Update is called once per frame
    void Update()
    {if(enemyState == EnemyState.CHASE)
        {
            ChasePlayer();
        }
    if(enemyState == EnemyState.ATTACK)
        {
            AttackPlayer();
        }
       
    }
    void ChasePlayer()
    {
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed = move_speed;
        if(navAgent.velocity.sqrMagnitude==0)
        {
            enemy_Anim.Walk(false);
        }
        else { enemy_Anim.Walk(true); }
        //print(Vector3.Distance(transform.position, playerTarget.position));
        if (Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance) { enemyState = EnemyState.ATTACK; }
    }
    void AttackPlayer()
    {navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        enemy_Anim.Walk(false );
        attackTimer += Time.deltaTime;
        if(attackTimer>waitBeforeAttackTime)
        {
            if(Random.Range(0,2)>0)
            {
                enemy_Anim.Attack1();
                sound.Attack_1();
            }
            else { enemy_Anim.Attack2();
                sound.Attack_2();
            }
            attackTimer = 0;
        }
        if(Vector3.Distance(transform.position, playerTarget.position) > attack_Distance + chasePlayerAfterAttackDistance)
        {
            navAgent.isStopped = false;
            enemyState = EnemyState.CHASE;
        }
   
    }
    void Acitvate_AttackPoint()
    {
        attackPoint.SetActive(true);
    }
    void Deacitvate_AttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }

}
