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
    public float lifeMax, speed, damage;
    public int points;
    protected float currentLife;

    [Header("References")]
    public LifeBar lifeBar;
    public Transform player;
    public GameController gc;
    protected NavMeshAgent agent;
    protected IAStates iaState = IAStates.Wait;

    protected Rigidbody2D body;


    protected Vector3 target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(gc.explosion, collision.transform.position, collision.transform.rotation);
        currentLife = lifeBar.UpdateBar(collision.GetComponent<Bullet>().damage, currentLife, lifeMax);
        if(currentLife <= 0)
        {
            Instantiate(gc.explosion, transform.position, transform.rotation);
            gc.UpdateScore(points);
            Destroy(transform.parent.gameObject);
        }
    }
    void StopChasing()
    {
        print("Parei");
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
