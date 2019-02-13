using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerController : MonoBehaviour {
	public float wideOfImageTarget;
	public float wideOfCamera;
	private float scaleFactor;

	public GameObject platform;
	public GameObject cameraFront;
	public GameObject cameraRight;
	public GameObject cameraBack;
	public GameObject cameraLeft;

    public GameObject player;
    public GameObject arCamera;

	private GameObject parentImageTarget;

	bool foundImage = false;

	
	// Use this for initialization
	void Start () {
		scaleFactor = 2*wideOfCamera/ wideOfImageTarget;
	}

    // Update is called once per frame
    void Update()
    {	


        if (foundImage)
        {
            if (parentImageTarget.gameObject.name == "FinalCube.Front")
            {
				float deltaX = -scaleFactor*(parentImageTarget.transform.position.x - this.transform.position.x);
				float deltaY = -scaleFactor*(parentImageTarget.transform.position.z - this.transform.position.z);

				platform.transform.position = new Vector3(cameraFront.transform.position.x + deltaX, cameraFront.transform.position.y + deltaY, platform.transform.position.z);
				
            }
            if (parentImageTarget.gameObject.name == "FinalCube.Right")
            {
                float deltaX = scaleFactor*(parentImageTarget.transform.position.y - this.transform.position.y);
				float deltaY = -scaleFactor*(parentImageTarget.transform.position.z - this.transform.position.z);

				platform.transform.position = new Vector3(cameraRight.transform.position.x + deltaX, cameraRight.transform.position.y + deltaY, platform.transform.position.z);
                Debug.Log(platform.transform.position);
            }
			if (parentImageTarget.gameObject.name == "FinalCube.Back")
            {
				float deltaX = scaleFactor*(parentImageTarget.transform.position.x - this.transform.position.x);
				float deltaY = -scaleFactor*(parentImageTarget.transform.position.z - this.transform.position.z);
			
				platform.transform.position = new Vector3(cameraBack.transform.position.x + deltaX, cameraBack.transform.position.y + deltaY, platform.transform.position.z);
            }
			if (parentImageTarget.gameObject.name == "FinalCube.Left")
            {
                float deltaX = -scaleFactor*(parentImageTarget.transform.position.y - this.transform.position.y);
				float deltaY = -scaleFactor*(parentImageTarget.transform.position.z - this.transform.position.z);

                platform.transform.position = new Vector3(cameraLeft.transform.position.x + deltaX, cameraLeft.transform.position.y + deltaY, platform.transform.position.z);
            }
            
        }

    }

	private void OnTriggerEnter(Collider other)
    {

			foundImage = true;

            Debug.Log("-----------------------------entered "+ other.gameObject.name);

			if(other.gameObject.name == "ColliderFront"){
				Debug.Log("-----------------------------Front");
				//Parent ImageTarget bekommen
				parentImageTarget = other.transform.parent.gameObject;
				//Koordinatenstrategie setzen mit Strategiemuster
				
			}

			if(other.gameObject.name == "ColliderRight"){
				Debug.Log("-----------------------------Right");
				parentImageTarget = other.transform.parent.gameObject;
			}

			if(other.gameObject.name == "ColliderBack"){
				Debug.Log("-----------------------------Back");
				parentImageTarget = other.transform.parent.gameObject;
			}

			if(other.gameObject.name == "ColliderLeft"){
				Debug.Log("-----------------------------Left");
				parentImageTarget = other.transform.parent.gameObject;
			}

    }

    private void OnTriggerExit(Collider other){
		foundImage = false;
		platform.transform.position = new Vector3(-30, platform.transform.position.y, platform.transform.position.z);
		Debug.Log("----------------------------------Exit Collider");
	}
}
