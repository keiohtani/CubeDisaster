using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour {

    public Transform lookAt;

    private Vector3 desiredPosition;
    private Vector3 offset = new Vector3(0, 8, -20f);
    private float smoothRate = 0.125f;

	// Use this for initialization
	void Start () {
        desiredPosition = new Vector3(lookAt.position.x, 0, 0) + offset;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if(lookAt != null){
            desiredPosition = new Vector3(lookAt.position.x, 0, 0) + offset;
            transform.position = Vector3.Lerp(desiredPosition, new Vector3(lookAt.position.x, 0, 0), smoothRate);
        }
	}
}
