using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy
{
    [Header("References - Child")]
    public GameObject bullet;
    public Transform frontal;

    [Header("Modifiers")]
    public float timeBetweenShots = 1;
    public float distanceToShoot = 3;


    float nextShotTime;
    bool chasing;
    Rigidbody2D body;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentLife = lifeMax;
        currentLife = lifeBar.UpdateBar(0, currentLife, lifeMax);
        iaState = IAStates.Deciding;
    }

    // Update is called once per frame
    void Update()
    {
        print(iaState);
        lifeBar.transform.position = transform.position;
        switch (iaState)
        {
            case IAStates.Deciding:
                RaycastHit2D ray = Physics2D.Linecast(transform.position, player.position, 7);
                if (ray.collider.CompareTag("Player"))
                {
                    chasing = true;
                    if(Vector2.Distance(transform.position, target) < distanceToShoot)
                    {
                        iaState = IAStates.Arrive;
                    } else
                    {
                        target = player.position;
                        iaState = IAStates.Moving;
                    }
                } else
                {
                    //RandomLocation(3);
                    RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.parent.up, 4, 7);
                    if (hitInfo.collider != null)
                    {
                        Debug.DrawRay(transform.position, hitInfo.point, Color.red);
                    }
                    else
                    {
                        Debug.DrawRay(transform.position, transform.position + transform.up * 4, Color.blue);
                    }
                    /*
                    if (Vector3.Distance(target, transform.parent.position) > 1)
                    {
                        iaState = IAStates.Moving;
                    }
                    */
                }
                break;
            case IAStates.Moving:
                if (Vector2.Distance(transform.position, target) > distanceToShoot)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                } else
                {
                    iaState = IAStates.Arrive;
                }
                break;
            case IAStates.Arrive:
                if (chasing)
                {
                    if(Time.time > nextShotTime)
                    {
                        Instantiate(bullet, frontal.position, frontal.rotation);
                        nextShotTime = Time.time + timeBetweenShots;
                    }
                }
                break;
        }
    }
    void Shoot()
    {

    }
    public void RandomLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitCircle * radius;
        randomDirection += transform.position;
        RaycastHit2D ray = Physics2D.Linecast(transform.position, randomDirection, 7);
        Debug.DrawRay(transform.position, randomDirection, Color.black);
        if (!ray.collider)
        {
            target = ray.point;
        } else
        {
            target = transform.position;
        }
        print(target);
    }
}
