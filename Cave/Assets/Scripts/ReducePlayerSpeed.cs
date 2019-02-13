using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReducePlayerSpeed : MonoBehaviour
{

    public GameObject player;
    public float playerSpeed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player && other.GetComponent<BoxCollider2D>().IsTouching(this.GetComponent<CapsuleCollider2D>()) && !other.GetComponent<CircleCollider2D>().IsTouching(this.GetComponent<BoxCollider2D>())){
            player.GetComponent<AutomaticRun>().moveUpBugFix4 = true;
            player.GetComponent<AutomaticRun>().speed = playerSpeed;
            Debug.Log(player.GetComponent<AutomaticRun>().speed);
        }

        else if(other.gameObject == player && other.IsTouching(this.GetComponent<CircleCollider2D>())){
            player.GetComponent<AutomaticRun>().moveUpBugFix4 = false;
            player.GetComponent<AutomaticRun>().speed = player.GetComponent<AutomaticRun>().actualSpeed;
        }
    }
}
