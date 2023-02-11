using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [Header("References")]
    public GameObject bullet;
    public Transform frontalGun;
    public Transform[] sideGun = new Transform[6];
    [Header("Modifiers")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    Rigidbody2D body;
    float rotate = 0;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Moviment();
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, frontalGun.position, transform.rotation);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            for (int i = 0; i < sideGun.Length; i++)
            {
                Instantiate(bullet, sideGun[i].position, sideGun[i].rotation);
            }
        }
    }
    void Moviment()
    {
        //Navegar para frente
        bool moving = Input.GetAxisRaw("Vertical") == 1;
        if (moving)
        {
            body.velocity = (moveSpeed * transform.up);
        } else
        {
            body.velocity = Vector2.zero;
        }

        //Rotacionar o barco
        rotate += Input.GetAxis("Horizontal");
        body.rotation = (-rotate / 10) * rotationSpeed;
    }
}
