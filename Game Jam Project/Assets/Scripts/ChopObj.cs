using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopObj : MonoBehaviour
{

    [SerializeField] private int health = 50;
    [SerializeField] private Transform spawnedItem;

    public void Damage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Vector3 playerPos = transform.position;
            Vector3 playerDirection = transform.up * 0.5f;
            Vector3 spawnPos = playerPos + playerDirection;
            Destroy(this.gameObject, .3f);
            Instantiate(spawnedItem, spawnPos, Quaternion.identity);
            
        }
    }
}
