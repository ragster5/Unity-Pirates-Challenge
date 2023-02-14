using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [Header("References")]
    public GameObject bullet;
    public Transform frontalGun, lifeBarPos;
    public Transform[] sideGun = new Transform[6];
    [Header("Modifiers")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f, lifeMax = 10f;
    Rigidbody2D body;
    float rotate = 0, currentLife;
    LifeBar lifeBar;
    [Header("Sprites")]
    public Sprite[] shipCondition;
    public Sprite[] flagCondition;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentLife = lifeMax;
        lifeBar = lifeBarPos.gameObject.GetComponent<LifeBar>();
        currentLife = lifeBar.UpdateBar(0, currentLife, lifeMax);
    }

    // Update is called once per frame
    void Update()
    {
        Moviment();
        Shoot();
        lifeBarPos.position = transform.position;//Posicionamento da barra de vida
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
    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))//Tiro Frontal
        {
            Instantiate(bullet, frontalGun.position, transform.rotation);
        }
        if (Input.GetButtonDown("Fire2"))//Tiro Lateral
        {
            for (int i = 0; i < sideGun.Length; i++)
            {
                Instantiate(bullet, sideGun[i].position, sideGun[i].rotation);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentLife = lifeBar.UpdateBar(collision.GetComponent<Bullet>().damage,currentLife, lifeMax);
    }
}