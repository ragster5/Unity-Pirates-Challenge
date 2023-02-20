using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chaser : Enemy
{
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gc = FindObjectOfType(typeof(GameController)) as GameController;
        body = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        currentLife = lifeMax;
        //currentLife = lifeBar.UpdateBar(0, currentLife, lifeMax);
        iaState = IAStates.Wait;
    }

    // Update is called once per frame
    void Update()
    {
        lifeBar.transform.position = transform.position;
        if (GameController.gamePhase.Equals(GamePhases.Game))
        {
            switch (iaState)
            {
                case IAStates.Wait:
                    agent.SetDestination(RandomNavmeshLocation(6));
                    iaState = IAStates.Moving;
                    break;
                case IAStates.Chasing:
                    Rotate(player.position);
                    agent.SetDestination(player.position);
                    break;
                case IAStates.Moving:
                    Rotate(target);
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        iaState = IAStates.Wait;
                    }
                    break;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(gc.explosion, transform.position, transform.rotation);
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            Destroy(transform.parent.gameObject);
        }
    }
}
