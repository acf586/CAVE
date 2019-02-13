using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlatformAnimation : MonoBehaviour
{

    private float opacity;
    private bool decrease;
    private bool increase;

    // Start is called before the first frame update
    void Start()
    {
        opacity = 0f;
        increase = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(increase)
        {
            opacity += 0.01f;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
            if (opacity >= 1)
            {
                increase = false;
                decrease = true;
            }
        }
        if(decrease)
        {
            opacity -= 0.012f;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
            if (opacity <= 0){
                decrease = false;
                increase = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player")){
            GameObject.FindWithTag("Player").GetComponent<AutomaticRun>().speed = 1;
            GameObject.FindWithTag("Player").GetComponent<AutomaticRun>().actualSpeed = 1;
            gameObject.SetActive(false);
        }
    }
}
