using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform player, limitUpRight, limitDownLeft;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > limitDownLeft.position.x && player.position.x < limitUpRight.position.x && player.position.y > limitDownLeft.position.y && player.position.y < limitUpRight.position.y)
        {
            if (Vector2.Distance(transform.position, player.position) < 1)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, transform.position.z), speed);
            } else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, transform.position.z), speed/2);
            }
        }
    }
}
