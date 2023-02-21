using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum IAStates
{
    Wait, Chasing, Moving
}
public abstract class Enemy : MonoBehaviour
{
    [Header("Modifiers")]
    public float lifeMax;
    public float damage;
    public int points;
    protected float currentLife;

    [Header("References")]
    public LifeBar lifeBar;
    public SpriteController spriteShip, spriteBigFlag, spriteSmallFlag;

    protected Rigidbody2D body;
    protected NavMeshAgent agent;
    protected IAStates iaState = IAStates.Wait;
    protected Transform player;
    protected GameController gc;
    protected Vector3 target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(gc.explosion, collision.transform.position, collision.transform.rotation);
        SoundEffectsController.PlaySound(SoundsList.Explosion);
        TakeDamage(collision.GetComponent<Bullet>().damage);
    }
    public void TakeDamage(float damage)
    {
        currentLife = lifeBar.UpdateBar(damage, currentLife, lifeMax);
        SpriteController();
        if (currentLife <= 0)
        {
            currentLife = 0;
            SpriteController();
            Instantiate(gc.explosion, transform.position, transform.rotation);
            SoundEffectsController.PlaySound(SoundsList.Explosion);
            gc.UpdateScore(points);
            body.velocity = Vector2.zero;
            Destroy(lifeBar.gameObject);
            Destroy(this);
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
    void StopChasing()
    {
        iaState = IAStates.Wait;
    }
    protected void Rotate(Vector3 target)
    {
        Vector2 lookDir = target - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        body.rotation = angle;
    }
    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
    protected IEnumerator ReachDestiny()
    {
        yield return new WaitForSeconds(1);
        iaState = IAStates.Wait;
    }
    private void OnBecameVisible()
    {
        iaState = IAStates.Chasing;
        CancelInvoke();
        StopAllCoroutines();
        
    }
    private void OnBecameInvisible()
    {
        Invoke("StopChasing", 3);
    }

}
