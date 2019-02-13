using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlatform : MonoBehaviour
{

    public GameObject platform;
    private AudioSource[] platformSounds; 
    private AudioSource placePlatfrom;
    private AudioSource removePlatform;

    private Collider2D Collider;

    private void Start()
    {
        platformSounds = platform.GetComponents<AudioSource>();
        placePlatfrom = platformSounds[0];
        removePlatform = platformSounds[1];

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == platform && other.IsTouching(this.GetComponent<BoxCollider2D>()) && other.IsTouching(this.GetComponent<CapsuleCollider2D>())){
            platform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            platform.GetComponent<PolygonCollider2D>().isTrigger = false;
            placePlatfrom.Play();

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == platform && !other.IsTouching(this.GetComponent<BoxCollider2D>()) && !other.IsTouching(this.GetComponent<CapsuleCollider2D>()))
        {
            platform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
            platform.GetComponent<PolygonCollider2D>().isTrigger = true;
            removePlatform.Play();
        }
    }
}