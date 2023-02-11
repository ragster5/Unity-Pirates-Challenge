using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f, rotationSpeed = 5f;
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
