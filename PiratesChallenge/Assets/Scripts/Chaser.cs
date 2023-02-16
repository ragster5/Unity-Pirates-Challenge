using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Enemy
{
    Rigidbody2D body;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentLife = lifeMax;
        currentLife = lifeBar.UpdateBar(0, currentLife, lifeMax);
        iaState = IAStates.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        lifeBar.transform.position = transform.position;
        switch (iaState)
        {
            case IAStates.Chase:
                //Chase();
                
                transform.position = Vector2.Lerp(transform.position, target, speed / 10 * Time.deltaTime);
                body.rotation = Mathf.Lerp(body.rotation, angle, 5 * Time.deltaTime);
                break;
            case IAStates.Obstacle:
                //Obstacle();
                break;
            case IAStates.Shoot:
                break;
            case IAStates.Idle:
                //Vision();
                RaycastHit2D ray = Physics2D.Linecast(transform.position, player.position, 7);
                if (!ray.collider.CompareTag("Player"))
                {
                    iaState = IAStates.Obstacle;
                }
                else
                {
                    Invoke("ChangeRoute", 2);
                    target = player.position;
                    iaState = IAStates.Chase;
                }
                break;
            case IAStates.Moving:
                //Moving();
                break;
            default:
                break;
        }
    }
    void ChangeRoute()
    {
        Vector2 lookDir = player.position - transform.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        iaState = IAStates.Idle;
    }
}
