using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [Header("References")]
    public GameObject bullet;
    public Transform frontalGun, lifeBarPos;
    public Transform[] sideGun = new Transform[6];
    public SpriteController spriteShip, spriteBigFlag, spriteSmallFlag;
    [Header("Modifiers")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f, lifeMax = 10f, frontalShootRate, sideShootRate;
    float rotate = 0, currentLife, timerToShoot;
    LifeBar lifeBar;

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
            Shoot();
            lifeBarPos.position = transform.position;//Posicionamento da barra de vida
        }
    }
    private void FixedUpdate()
    {
        if (GameController.gamePhase.Equals(GamePhases.Game))
        {
            Moviment();
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
        timerToShoot += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timerToShoot > frontalShootRate)//Tiro Frontal
        {
            Instantiate(bullet, frontalGun.position, transform.rotation);
            timerToShoot = 0;
        }
        if (Input.GetButtonDown("Fire2") && timerToShoot > sideShootRate)//Tiro Lateral
        {
            for (int i = 0; i < sideGun.Length; i++)
            {
                Instantiate(bullet, sideGun[i].position, sideGun[i].rotation);
            }
            timerToShoot = 0;
        }
    }
    void SpriteController()
    {
        spriteShip.ChangeSprite(currentLife, lifeMax);
        Instantiate(gc.fire, spriteBigFlag.transform.position, spriteBigFlag.transform.rotation);
        spriteBigFlag.ChangeSprite(currentLife, lifeMax);
        Instantiate(gc.fire, spriteSmallFlag.transform.position, spriteSmallFlag.transform.rotation);
        spriteSmallFlag.ChangeSprite(currentLife, lifeMax);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(collision.GetComponent<Bullet>().damage);
        Instantiate(gc.explosion, collision.transform.position, collision.transform.rotation);
        SoundEffectsController.PlaySound(SoundsList.Explosion);
    }
    
    public void TakeDamage(float damage)
    {
        currentLife = lifeBar.UpdateBar(damage, currentLife, lifeMax);
        SpriteController();
        if (currentLife <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(gc.explosion, transform.position, transform.rotation);
        SoundEffectsController.PlaySound(SoundsList.Explosion);
        GameController.gamePhase = GamePhases.GameOver;
        body.velocity = Vector2.zero;
        SpriteController();
        gc.GameOverMenu();
    }
}