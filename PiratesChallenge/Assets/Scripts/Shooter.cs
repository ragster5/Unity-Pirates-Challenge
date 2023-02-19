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
    public float shotRate;

    bool chasing;
    float timerToShot;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        currentLife = lifeMax;
        currentLife = lifeBar.UpdateBar(0, currentLife, lifeMax);
        iaState = IAStates.Wait;
    }

    // Update is called once per frame
    void Update()
    {
        print(iaState);
        lifeBar.transform.position = transform.position;
        switch (iaState)
        {
            case IAStates.Wait:
                    agent.SetDestination(RandomNavmeshLocation(6));
                    iaState = IAStates.Moving;
                
                break;
            case IAStates.Chasing:
                Rotate(player.position);
                agent.SetDestination(player.position);
                if(agent.remainingDistance < agent.stoppingDistance + 2)
                {
                    Shoot();
                } else
                {
                    timerToShot = 0;
                }
                break;
            case IAStates.Moving:
                Rotate(target);
                if(agent.remainingDistance <= agent.stoppingDistance)
                {
                    StartCoroutine("ReachDestiny");
                }
                break;
        }
    }
    void Shoot()
    {
        timerToShot += Time.deltaTime;
        if(timerToShot >= shotRate)
        {
            Instantiate(bullet, frontal.position, frontal.rotation);
            timerToShot = 0;
        }
    }

}
