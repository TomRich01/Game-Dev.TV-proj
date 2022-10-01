using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{

    public bool isInGroup;
    public AI zomAI;
    private NavMeshAgent agent;
    private CapsuleCollider capsuleCollider;
    private Rigidbody rb;
    private AudioSource audioZom;
    public AudioClip zomDmg;
    public enum AI
    {
        idle = 0,
        walk = 1,
        attack = 2,
        dead = 3
    }

    private Animator animator;
    public int health = 10;
    public GameObject Target { get; set; }
    void Start()
    {
        audioZom = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

       
    }

    
    void Update()
    {
        switch (zomAI)
        {
            case AI.idle:
                if (Target != null)
                {
                    agent.transform.LookAt(Target.transform.position);
                }
                break;
            case AI.walk:
                Invoke("MoveToTarget", 3f);
                break;
            case AI.attack: 
                    Invoke("AttackTarget", 0.5f);
                break;
            case AI.dead:
                Invoke("OnDead", 1f);
                break;
            default:
                zomAI = 0;
                break;
        }
    }


    void MoveToTarget()
    {
        agent.isStopped = false;
        agent.updatePosition = true;
        agent.SetDestination(Target.transform.position);
        agent.speed = 1.5f;
        animator.SetBool("move", true);
        if (health < 1)
        {
            zomAI = AI.dead;
        }
        if (Vector3.Distance(Target.transform.position, transform.position) <= rangeAttack)
        {
            zomAI = AI.attack;
        }
    }

    void AttackTarget()
    {
        isAttacking = true;
        agent.isStopped = true;
        agent.speed = 0f;
        animator.SetBool("move", false);
        animator.SetTrigger("Attack");
        if (Vector3.Distance(Target.transform.position, transform.position) > rangeAttack && health > 0)
        {
            zomAI = AI.walk;
            isAttacking = false;
        }
    }

    void OnDead()
    {
        agent.baseOffset = -0.12f;
        animator.SetBool("move", false);
        agent.isStopped = true;
        animator.SetBool("Dead", true);
        Destroy(rb);
        Destroy(capsuleCollider);
        Destroy(gameObject, 5f);
    }

    public float rangeAttack = 1f;
    public bool isAttacking;


    public void Damage(int amount)
    {
        health -= amount;
        animator.SetTrigger("Damage");
        audioZom.PlayOneShot(zomDmg);
    }

}
