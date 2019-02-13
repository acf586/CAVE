using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlatformAnimationMoveVertically : MonoBehaviour
{

    private float opacity;
    private Vector3 startPosition;
    private float startYPosition;
    private float variableYCoordinate;
    private bool threadSleep;
    private bool increase;
    private bool decrease;

    // Start is called before the first frame update
    void Start()
    {
        startYPosition = transform.position.y;
        startPosition = transform.position;
        variableYCoordinate = transform.position.y;

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
                MoveUp(true);
                opacity += .007f;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
                if (opacity >= 1)
                {
                    //threadSleep = true;
                    //opacity = 0f;
                    increase = false;
                    decrease = true;
                    MoveUp(false);
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

    IEnumerator Wait(){
        yield return new WaitForSecondsRealtime(.8f);
        transform.position = startPosition;
        variableYCoordinate = startYPosition;
        threadSleep = false;
    }

    private void MoveUp(bool move)
    {
        if (move)
        {
            variableYCoordinate += .01f;
            transform.position = new Vector3(transform.position.x, variableYCoordinate, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
