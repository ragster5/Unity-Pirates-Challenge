using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum IAStates
{
    Chase, Obstacle, Shoot, Rotate
}
public abstract class Enemy : MonoBehaviour
{
    public float lifeMax, speed;
    protected float currentLife;
    public LifeBar lifeBar;
    public Transform player;
    protected IAStates iaState = IAStates.Chase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentLife = lifeBar.UpdateBar(collision.GetComponent<Bullet>().damage, currentLife, lifeMax);
        if(currentLife <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
    protected void Chase()
    {
        transform.position = Vector2.Lerp(transform.position, player.position, speed * Time.deltaTime);
    }
    
}
