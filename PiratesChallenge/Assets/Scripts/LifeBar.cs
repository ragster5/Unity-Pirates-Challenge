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
        print(bar.localScale);
        barMaxSize = bar.localScale.x;
        
    }

    // Update is called once per frame
    public float UpdateBar(float damage, float life, float maxLife)
    {
        life -= damage;
        if(life < 0)
        {
            life = 0;
        }
        float size = life * barMaxSize / maxLife;
        bar.localScale = new Vector2(size, bar.localScale.y);
        return life;
    }
}
