using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoundsList
{
    Explosion, Shoot, CountDown, Ready
}
public class SoundEffectsController : MonoBehaviour
{
    public static SoundEffectsController instance;
    public AudioClip explosion, shoot, countDown, ready;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySound(SoundsList currentsound)
    {
        switch (currentsound)
        {
            case SoundsList.Explosion:
                instance.GetComponent<AudioSource>().PlayOneShot(instance.explosion);
                break;
            case SoundsList.Shoot:
                instance.GetComponent<AudioSource>().PlayOneShot(instance.shoot);
                break;
            case SoundsList.CountDown:
                instance.GetComponent<AudioSource>().PlayOneShot(instance.countDown);
                break;
            case SoundsList.Ready:
                instance.GetComponent<AudioSource>().PlayOneShot(instance.ready);
                break;
        }
    }
}
