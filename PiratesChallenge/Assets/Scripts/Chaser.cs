using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Enemy
{
    /*
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
                    body.rotation = Mathf.Lerp(body.rotation, angle, 2 * Time.deltaTime);
                    transform.position = Vector2.Lerp(transform.position, target, speed / 10 * Time.deltaTime);
                break;
            case IAStates.Obstacle:
                //Obstacle();
                break;
            case IAStates.Shoot:
                break;
            case IAStates.Idle:
                //Vision();
                Rotate();
                RaycastHit2D ray = Physics2D.Linecast(transform.position, player.position, 7);
                if (!ray.collider.CompareTag("Player"))
                {
                    iaState = IAStates.Obstacle;
                }
                else
                {
                    Invoke("ChangeRoute", 1);
                    target = player.position;
                    iaState = IAStates.Chase;
                }
                break;
            case IAStates.Moving:
                //Moving();
                break;
            case IAStates.Rotate:

                break;
            default:
                break;
        }
    }
    void ChangeRoute()
    {
        iaState = IAStates.Idle;
    }
    void Rotate()
    {
        Vector2 lookDir = player.position - transform.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    */
}
