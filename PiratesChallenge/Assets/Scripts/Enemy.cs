using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum IAStates
{
    Deciding, Moving, Arrive
}
public abstract class Enemy : MonoBehaviour
{
    public float lifeMax, speed, damage;
    public int points;
    protected float currentLife;

    [Header("References")]
    public LifeBar lifeBar;
    public Transform player;
    public GameController gc;
    protected NavMeshAgent agent;
    protected IAStates iaState = IAStates.Deciding;


    protected Vector3 target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(gc.explosion, collision.transform.position, collision.transform.rotation);
        currentLife = lifeBar.UpdateBar(collision.GetComponent<Bullet>().damage, currentLife, lifeMax);
        if(currentLife <= 0)
        {
            Instantiate(gc.explosion, transform.position, transform.rotation);
            gc.UpdateScore(points);
            Destroy(transform.parent.gameObject);
        }
    }
    
}
