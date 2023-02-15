using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    SpriteRenderer spriteR;
    public Sprite[] spriteList;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
    }
    public void ChangeSprite(float currentLife, float lifeMax)
    {
        int r = (int)(((spriteList.Length - 1) * (currentLife * 10) / lifeMax - 1) / lifeMax - 1);
        spriteR.sprite = spriteList[spriteList.Length - 2 - r];
    }
}
