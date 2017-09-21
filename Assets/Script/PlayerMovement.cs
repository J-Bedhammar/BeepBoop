using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rig_;
    MicrophoneInput micInput;

	// Use this for initialization
	void Start () {
        rig_ = GetComponent<Rigidbody2D>();
        micInput = FindObjectOfType<MicrophoneInput>();
	}
	
	// Update is called once per frame
	void Update () {
        print(micInput.GetFrequency());

        if (micInput.GetFrequency() >= 300 && micInput.GetFrequency() < 500)
		    rig_.MovePosition(transform.position + new Vector3(micInput.GetFrequency() /-1000, 0, 0));
        else if (micInput.GetFrequency() >= 500 && micInput.GetFrequency() < 850)
            rig_.MovePosition(transform.position + new Vector3(micInput.GetFrequency() /1500, 0, 0));
        else if (micInput.GetFrequency() >= 850)
            rig_.MovePosition(transform.position + new Vector3(0, micInput.GetFrequency() /2800, 0));
        else
            rig_.MovePosition(transform.position + new Vector3(0, 0, 0));

    }
}
