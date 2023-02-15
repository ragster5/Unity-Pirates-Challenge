using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [Header("References")]
    public GameObject bullet;
    public GameObject explosion, fire;
    public Transform frontalGun, lifeBarPos;
    public Transform[] sideGun = new Transform[6];
    public SpriteRenderer spriteShip, spriteBigFlag, spriteSmallFlag;
    [Header("Modifiers")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f, lifeMax = 10f;
    float rotate = 0, currentLife;
    LifeBar lifeBar;
    [Header("Sprites")]
    public Sprite[] shipCondition;
    public Sprite[] bigFlagCondition;
    public Sprite[] smallFlagCondition;

    //Referencias privadas
    Rigidbody2D body;
    GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType(typeof(GameController)) as GameController;
        body = GetComponent<Rigidbody2D>();
        currentLife = lifeMax;
        lifeBar = lifeBarPos.gameObject.GetComponent<LifeBar>();
        currentLife = lifeBar.UpdateBar(0, currentLife, lifeMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gamePhase.Equals(GamePhases.Game))
        {
            Moviment();
            Shoot();
            lifeBarPos.position = transform.position;//Posicionamento da barra de vida
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
    void SpriteController()
    {
        //Troca da sprite do barco
        int state = (int)((currentLife * 10) / lifeMax);
        if(state > 7)
        {
            spriteShip.sprite = shipCondition[0];
            spriteBigFlag.sprite = bigFlagCondition[0];
            spriteSmallFlag.sprite = smallFlagCondition[0];
        } else if (state > 4)
        {
            spriteShip.sprite = shipCondition[1];
            Instantiate(fire, spriteBigFlag.transform.position, spriteBigFlag.transform.rotation);
            spriteBigFlag.sprite = bigFlagCondition[1];
            Instantiate(fire, spriteSmallFlag.transform.position, spriteBigFlag.transform.rotation);
            spriteSmallFlag.sprite = smallFlagCondition[1];
        } else if (state > 2)
        {
            spriteShip.sprite = shipCondition[2];
            Instantiate(fire, spriteBigFlag.transform.position, spriteBigFlag.transform.rotation);
            spriteBigFlag.sprite = bigFlagCondition[2];
            Instantiate(fire, spriteSmallFlag.transform.position, spriteBigFlag.transform.rotation);
            spriteSmallFlag.sprite = smallFlagCondition[2];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //currentLife = lifeBar.UpdateBar(collision.GetComponent<Bullet>().damage,currentLife, lifeMax);
        currentLife = lifeBar.UpdateBar(2,currentLife, lifeMax);
        Instantiate(explosion, collision.transform.position, collision.transform.rotation);
        SpriteController();
        if (currentLife == 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameController.gamePhase = GamePhases.GameOver;
        spriteShip.sprite = shipCondition[3];
        spriteBigFlag.sprite = bigFlagCondition[3];
        spriteSmallFlag.sprite = smallFlagCondition[3];
        gc.GameOverMenu();
    }
}