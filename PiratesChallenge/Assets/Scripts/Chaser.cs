using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        currentLife = lifeMax;
        currentLife = lifeBar.UpdateBar(0, currentLife, lifeMax);
    }

    // Update is called once per frame
    void Update()
    {
        lifeBar.transform.position = transform.position;
        switch (iaState)
        {
            case IAStates.Chase:
                Chase();
                break;
            case IAStates.Obstacle:
                Obstacle();
                break;
            case IAStates.Shoot:
                break;
            case IAStates.Idle:
                Vision();
                break;
            case IAStates.Moving:
                Moving();
                break;
            default:
                break;
        }
    }
}
