using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D body;
    [Header("Modifiers")]
    public float damage = 2f;
    public float speed = 10f;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = (speed * transform.up);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
