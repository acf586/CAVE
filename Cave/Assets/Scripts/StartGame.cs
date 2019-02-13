using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject platform;
    public GameObject [] tutorials;
    public GameObject platformActivates;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject==platform){
            arCamera.GetComponent<GameController>().SetScreen("level");
            platform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
            for (int i = 0; i < tutorials.Length; i++){
                tutorials[i].SetActive(true);
            }
            platformActivates.SetActive(true);
        }
    }
}
