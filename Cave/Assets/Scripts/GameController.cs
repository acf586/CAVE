using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private const string startScreen = "Start";
    private const string winningScreen = "Finish";
    private const string deathScreen = "Water";
    private const string level = "level";
    private const string startPath = "Sprites/StartScreen";
    private const string winPath = "Sprites/WinScreen";
    private const string deathPath = "Sprites/DeathScreen";

    public GameObject player;
    public GameObject water;
    public GameObject[] screens;

    // Start is called before the first frame update
    void Start()
    {
       
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }

        SetScreen(startScreen);
    }

    public void SetScreen(string screen){
        switch (screen){
            case startScreen:
                player.GetComponent<AutomaticRun>().speed = 0;
                player.GetComponent<AudioSource>().Stop();
                for (int i = 0; i < screens.Length; i++){
                    screens[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(startPath);
                    screens[0].SetActive(true);
                }
                break;
            case winningScreen:
                player.GetComponent<AutomaticRun>().speed = 0;
                player.GetComponent<AudioSource>().Stop();
                for (int i = 0; i < screens.Length; i++)
                {
                    screens[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(winPath);
                    screens[i].SetActive(true);
                }
                break;
            case deathScreen:
                player.GetComponent<AutomaticRun>().speed = 0;
                player.GetComponent<AudioSource>().Stop();
                for (int i = 0; i < screens.Length; i++)
                {
                    screens[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(deathPath);
                    screens[i].SetActive(true);
                }
                break;
            case level:
                player.GetComponent<AutomaticRun>().speed = 0.9f;
                player.GetComponent<AutomaticRun>().actualSpeed = player.GetComponent<AutomaticRun>().speed;
                player.GetComponent<AudioSource>().Play();
                player.GetComponent<AudioSource>().loop = true;
                player.GetComponent<AudioSource>().pitch = .7f;

                GameObject.Find("ARCamera").GetComponents<AudioSource>()[1].volume = 1;
                GameObject.Find("ARCamera").GetComponents<AudioSource>()[1].Play();
                for (int i = 0; i < screens.Length; i++){
                    screens[i].SetActive(false);
                }
                water.GetComponent<WaterController>().velocity = 0.055f;
                break;
        }
    }
}
