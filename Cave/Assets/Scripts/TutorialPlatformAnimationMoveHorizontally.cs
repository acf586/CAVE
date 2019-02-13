using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlatformAnimationMoveHorizontally : MonoBehaviour
{

    private float opacity;
    private Vector3 startPosition;
    private float startXPosition;
    private float variableXCoordinate;
    private bool threadSleep;
    private bool increase;
    private bool decrease;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startXPosition = transform.position.x;
        variableXCoordinate = transform.position.x;

        opacity = 0f;

        threadSleep = false;
        increase = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!threadSleep)
        {
            if (increase)
            {
                MoveRight(true);
                opacity += .007f;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
                if (opacity >= 1)
                {
                    //threadSleep = true;
                    //opacity = 0f;
                    increase = false;
                    decrease = true;
                    MoveRight(false);
                }
            }

            if (decrease)
            {
                opacity -= .02f;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
                if (opacity <= 0)
                {
                    decrease = false;
                    threadSleep = true;
                    increase = true;
                    StartCoroutine(Wait());
                }
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(.8f);
        transform.position = startPosition;
        variableXCoordinate = startXPosition;
        threadSleep = false;
    }

    private void MoveRight(bool move)
    {
        if (move)
        {
            variableXCoordinate += .01f;
            transform.position = new Vector3(variableXCoordinate, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player")){
            gameObject.SetActive(false);
        }
    }
}
