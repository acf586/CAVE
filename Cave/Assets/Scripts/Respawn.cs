using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform startPosition;
    public Transform platformStartPosition;
    public GameObject platform;
    public GameObject camera;
    public GameObject water;
    public GameObject [] tutorials;
    public GameObject[] allPlatformActivates;
    public GameObject allPlatformActivates2;
    public GameObject player;

    private AudioSource[] waterAudios;
    private AudioSource enterWater;
    private AudioSource waterDeathSound;
    private AudioSource deathScreamSound;

    private AudioSource[] finishAudios;
    private AudioSource finishSound;
    private AudioSource winSound;

    private bool fadingOut;

    private void Start()
    {

        waterAudios = GameObject.Find("Water").GetComponents<AudioSource>();
        enterWater = waterAudios[0];
        waterDeathSound = waterAudios[1];
        deathScreamSound = waterAudios[2];

        finishAudios = GameObject.Find("Finish").GetComponents<AudioSource>();
        finishSound = finishAudios[0];
        winSound = finishAudios[1];

        fadingOut = false;
    }

    private void Update()
    {
        if(fadingOut){
            fadeOut(GameObject.Find("ARCamera").GetComponents<AudioSource>()[1]);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(this.name.Equals("Water") && other.tag.Equals("Player") && other.GetComponent<CircleCollider2D>().IsTouching(GetComponent<BoxCollider2D>()) && !other.GetComponent<BoxCollider2D>().IsTouching(GetComponent<BoxCollider2D>())){
            enterWater.Play();
            enterWater.loop = true;
        }

        if(other.tag.Equals("Player") && other.GetComponent<BoxCollider2D>().IsTouching(GetComponent<BoxCollider2D>())){
            other.transform.position = startPosition.position;

            platform.transform.position = platformStartPosition.position;

            camera.GetComponent<GameController>().SetScreen(this.name);

            water.GetComponent<WaterController>().SetWaterStartPosition();
            water.GetComponent<WaterController>().velocity = 0f;

            player.GetComponent<AutomaticRun>().speed = 0;
            player.GetComponent<AutomaticRun>().actualSpeed = 0;

            for (int i = 0; i < tutorials.Length; i++){
                tutorials[i].SetActive(false);
            }

            for (int i = 4; i < allPlatformActivates.Length; i++){
                allPlatformActivates[i].SetActive(false);
            }

            allPlatformActivates2.SetActive(false);

            if(this.name.Equals("Water")){
                waterDeathSound.Play();
                deathScreamSound.Play();
                enterWater.loop = false;
                fadingOut = true;
            }

            if(this.name.Equals("Finish")){
                winSound.Play();
            }
        }

        else if(this.name.Equals("Finish") && other.tag.Equals("Player") && other.IsTouching(this.GetComponent<CircleCollider2D>())){
            finishSound.Play();
            fadingOut = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (this.name.Equals("Water") && other.tag.Equals("Player"))
        {
            Debug.Log("Exited");
            enterWater.loop = false;;
        }
    }

    void fadeOut(AudioSource source){
         source.volume -= 0.2f * Time.deltaTime;
        if(source.volume <= 0){
            fadingOut = false;
        }
    }
}
