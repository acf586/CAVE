using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeam : MonoBehaviour
{   
    public Transform beamPoint;
    public GameObject[] allPlatformActivates;
    public GameObject player;
    public float playerSpeed;
    public float walkingSpeed;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Player"){

            ActivatePossiblePlatforms(beamPoint.name);

            other.transform.position = beamPoint.position;

            player.GetComponent<AutomaticRun>().speed = this.playerSpeed;
            player.GetComponent<AutomaticRun>().actualSpeed = player.GetComponent<AutomaticRun>().speed;
            player.GetComponent<AudioSource>().pitch = walkingSpeed;

            GameObject.Find("Water").GetComponent<WaterController>().velocity = 0.07f;
        }   
    }

    void ActivatePossiblePlatforms(string newBeamPoint){
        switch(newBeamPoint)
        {
            case("StartSecondFloor"):
                for (int i = 4; i < 9; i++){
                    allPlatformActivates[i].SetActive(true);
                }
                break;
            case("StartThirdFloor"):
                for (int i = 9; i < allPlatformActivates.Length; i++){
                    allPlatformActivates[i].SetActive(true);
                }
                break;
        }
    }
}
