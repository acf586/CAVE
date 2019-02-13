using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticRun : MonoBehaviour
{
    public float speed;
    public float actualSpeed;
    public bool moveUpBugFix4;
    public Transform startSpawn;

    void Start()
    {
        moveUpBugFix4 = false;
    }

    void Update()
    {
        this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        //GetComponent<Animator>().SetFloat("Speed", speed);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("MoveUpBugFix"))
        {
            if (GetComponent<CircleCollider2D>().IsTouching(other.GetComponent<BoxCollider2D>()))
            {
                speed = 0;
            }
            else if(GetComponent<BoxCollider2D>().IsTouching(other.GetComponent<CapsuleCollider2D>()) && !GetComponent<CircleCollider2D>().IsTouching(other.GetComponent<BoxCollider2D>()) && !moveUpBugFix4){
                speed = actualSpeed;
            }
        }
    }
}