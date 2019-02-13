using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{   
    public float velocity;
    private Vector3 waterStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.7f);
        waterStartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.up * velocity* Time.deltaTime);
    }

    public void SetWaterStartPosition(){
        transform.position = waterStartPosition;
    }
}
