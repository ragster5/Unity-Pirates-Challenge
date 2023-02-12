using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    [Header("References")]
    public Transform bar;
    float barMaxSize;
    // Start is called before the first frame update
    void Start()
    {
        barMaxSize = transform.localScale.x;
    }

    // Update is called once per frame
    public float UpdateBar(float damage, float life, float maxLife)
    {
        life -= damage;
        float size = life * barMaxSize / maxLife;
        bar.localScale = new Vector2(size, bar.localScale.y);
        return life;
    }
}
