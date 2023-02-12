using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float lifeMax, speed;
    protected float currentLife;
    public LifeBar lifeBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentLife = lifeBar.UpdateBar(collision.GetComponent<Bullet>().damage, currentLife, lifeMax);
        if(currentLife <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
