using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupController : MonoBehaviour
{
    public GameObject[] zombies;

    public GameObject target;


    private void Start()
    {
        //Debug.Log(target);
        foreach (GameObject zombie in zombies)
        {
           // Debug.Log(target);
            zombie.GetComponent<ZombieAI>().Target = target;
            zombie.GetComponent<ZombieAI>().zomAI = ZombieAI.AI.walk;
        }
    }

   
}
