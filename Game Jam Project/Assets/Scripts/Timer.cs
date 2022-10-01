using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Timer : MonoBehaviour
{
    public float StartTime;
    float CurrentTime;
    float TimeEnd = 0;

    private Ending ending;

    private Hero hero;

    [SerializeField] TMP_Text textmesh;
   
    void Start()
    {
        hero = FindObjectOfType<Hero>();
        CurrentTime = StartTime;
        ending = GetComponent<Ending>();
       
    }


    void Update()
    {
        if (CurrentTime <= StartTime)
        {
            CurrentTime -= 1 * Time.deltaTime;
            textmesh.text = CurrentTime.ToString("0");
        }

        if (CurrentTime <= TimeEnd)
        {
            ending.Won();
            

        }
    }
}
