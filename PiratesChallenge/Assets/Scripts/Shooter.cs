using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shooter : Enemy
{
    [Header("References - Child")]
    public GameObject bullet;
    public Transform frontal;

    [Header("Modifiers")]


    float nextShotTime;
    bool chasing;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        currentLife = lifeMax;
        currentLife = lifeBar.UpdateBar(0, currentLife, lifeMax);
        iaState = IAStates.Deciding;
    }

    // Update is called once per frame
    void Update()
    {
        lifeBar.transform.position = transform.position;
        switch (iaState)
        {
            case IAStates.Deciding:
                
                break;
            case IAStates.Moving:
                
                break;
            case IAStates.Arrive:
                
                break;
        }
    }
    void Shoot()
    {

    }
}
