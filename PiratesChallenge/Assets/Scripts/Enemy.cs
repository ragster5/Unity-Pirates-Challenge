using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum IAStates
{
    Chase, Obstacle, Shoot, Rotate, Idle, Moving
}
public abstract class Enemy : MonoBehaviour
{
    public float lifeMax, speed, damage;
    public int points;
    protected float currentLife;

    [Header("References")]
    public LifeBar lifeBar;
    public Transform player;
    public GameObject explosion;
    public GameController gc;
    protected IAStates iaState = IAStates.Idle;


    protected Vector3 target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosion, collision.transform.position, collision.transform.rotation);
        currentLife = lifeBar.UpdateBar(collision.GetComponent<Bullet>().damage, currentLife, lifeMax);
        if(currentLife <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gc.UpdateScore(points);
            Destroy(transform.parent.gameObject);
        }
    }
    
    protected void Chase()
    {
        transform.position = Vector2.Lerp(transform.position, player.position, speed/10 * Time.deltaTime);
    }
    protected void Vision()
    {
        RaycastHit2D ray = Physics2D.Linecast(transform.position, player.position, 7);
        if (!ray.collider.CompareTag("Player"))
        {
            iaState = IAStates.Obstacle;
        } else
        {
            iaState = IAStates.Chase;
        }
    }
    protected void Obstacle()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.up, 3, 7);
        if(!ray)
        {
            target = new Vector2(Random.Range(0, 2), Random.Range(0, 3));
            iaState = IAStates.Moving;
        }
    }
    protected void Moving()
    {
        transform.position = Vector2.Lerp(transform.position, target, speed / 10 * Time.deltaTime);
        if (transform.position.Equals(target))
        {
            iaState = IAStates.Obstacle;
        }
        Vision();
    }
    
}
