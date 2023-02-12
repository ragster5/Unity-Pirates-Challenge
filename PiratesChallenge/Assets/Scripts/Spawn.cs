using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform limitA, limitB;

    public void SpawnRandomEnemy(GameObject prefab)
    {
        Instantiate(prefab, new Vector2(Random.Range(limitA.position.x, limitB.position.y), Random.Range(limitA.position.x, limitB.position.y)), transform.rotation);
    }
}
