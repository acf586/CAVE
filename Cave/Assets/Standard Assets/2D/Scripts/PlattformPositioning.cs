using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformPositioning : MonoBehaviour {
	public Transform mainImage;

	public Transform plattformMarker;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		this.transform.position = new Vector3( plattformMarker.position.x , plattformMarker.position.y, mainImage.position.z );
		
	}
}
