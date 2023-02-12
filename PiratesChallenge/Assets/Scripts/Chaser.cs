using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Enemy
{
    public Transform player;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = lifeMax;
        body = GetComponent<Rigidbody2D>();
        currentLife = lifeBar.UpdateBar(0, currentLife, lifeMax);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.position, 0.2f * Time.deltaTime);
        lifeBar.transform.position = transform.position;
    }
}
