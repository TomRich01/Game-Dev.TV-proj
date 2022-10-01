using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject hitArea;
    private ZombieAI zombieAI;
    void Awake()
    {
        animator = GetComponent<Animator>();
        hitArea.SetActive(false);
        zombieAI = GetComponent<ZombieAI>();

    }


    private void AnimationEvent_OnSwing()
    {
        Vector3 colliderSize = Vector3.one * 1f;

        Collider[] colliderArray = Physics.OverlapBox(hitArea.transform.position, colliderSize);
        foreach (Collider collider in colliderArray)
        {
            if (collider.GetComponent<Hero>())
            {

                float damageAmount = Random.Range(10, 20);
                collider.GetComponent<Hero>().lifecycle.Damage(damageAmount);
                hitArea.SetActive(false);
            }
            else
            {
                hitArea.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (zombieAI.isAttacking)
        {
           
                animator.SetTrigger("Attack");
                hitArea.SetActive(true);
            
        }


    }
}
