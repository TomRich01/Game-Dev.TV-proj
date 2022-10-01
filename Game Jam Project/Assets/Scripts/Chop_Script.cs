using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chop_Script : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject hitArea;
    private CheckInteraction checkInteraction;
    private bool canChop;
   void Awake()
    {
        animator = GetComponent<Animator>();
        hitArea.SetActive(false);
        checkInteraction = GameObject.FindObjectOfType<CheckInteraction>();
    }


    private void AnimationEvent_OnSwing()
    {
        Vector3 colliderSize = Vector3.one * 1f;
        
        Collider[] colliderArray = Physics.OverlapBox(hitArea.transform.position, colliderSize);
        foreach (Collider collider in colliderArray)
        {
            if (collider.GetComponent<ZombieAI>())
            {
                
                int damageAmount = Random.Range(5, 10);
                collider.GetComponent<ZombieAI>().Damage(damageAmount);
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
        canChop = checkInteraction.canChop;
       

        if (canChop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Attack");
                hitArea.SetActive(true);
            }
        }
        
    }

    
}
