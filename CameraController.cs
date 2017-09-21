using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    Transform look_towards;

    Vector3 offset_;
	// Use this for initialization
	void Start () {
        look_towards = FindObjectOfType<PlayerMovement>().gameObject.transform;
        offset_ = transform.position - look_towards.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = look_towards.position + offset_;
	}
}
