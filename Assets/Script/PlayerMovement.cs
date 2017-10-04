using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rig_;
    MicrophoneInput2 micInput;
    Animator Anim;
    

	// Use this for initialization
	void Start () {
        rig_ = GetComponent<Rigidbody2D>();
        micInput = FindObjectOfType<MicrophoneInput2>();
        Anim = GetComponent<Animator>();
        Anim.SetBool("Grounded", true);
       
	}
	
	// Update is called once per frame
	void Update () {
        print(micInput.GetFrequency());

        if (micInput.GetFrequency() >= 100 && micInput.GetFrequency() < 220)
            rig_.MovePosition(transform.position + new Vector3(-1, 0, 0)); //micInput.GetFrequency() /-1000
        else if (micInput.GetFrequency() >= 250 && micInput.GetFrequency() < 400)
            {
            rig_.MovePosition(transform.position + new Vector3(1, 0, 0)); //micInput.GetFrequency() /1500
            Anim.SetFloat("Speed", 1);
            }
        else if (micInput.GetFrequency() >= 400)
            {
            rig_.MovePosition(transform.position + new Vector3(0, 1, 0)); //micInput.GetFrequency() /280
            Anim.SetBool("Grounded", false);
            }
        else
        {
            Anim.SetBool("Grounded", true);
            Anim.SetFloat("Speed", 0);

        }
    }
}
