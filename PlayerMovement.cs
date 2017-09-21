using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rig_;
    MicCode2 micInput;

	// Use this for initialization
	void Start () {
        rig_ = GetComponent<Rigidbody2D>();
        micInput = FindObjectOfType<MicCode2>();
	}
	
	// Update is called once per frame
	void Update () {
        print(micInput.GetFundamentalFrequency());

        if (micInput.GetFundamentalFrequency() >= 300 && micInput.GetFundamentalFrequency() < 500)
		    rig_.MovePosition(transform.position + new Vector3(micInput.GetFundamentalFrequency() /-1000, 0, 0));
        else if (micInput.GetFundamentalFrequency() >= 500 && micInput.GetFundamentalFrequency() < 850)
            rig_.MovePosition(transform.position + new Vector3(micInput.GetFundamentalFrequency() /1500, 0, 0));
        else if (micInput.GetFundamentalFrequency() >= 850)
            rig_.MovePosition(transform.position + new Vector3(0, micInput.GetFundamentalFrequency() /2800, 0));
        else
            rig_.MovePosition(transform.position + new Vector3(0, 0, 0));

    }
}
