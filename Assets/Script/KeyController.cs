using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

	// Use this for initialization
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow)) {
            print("Right");
            transform.Translate(1,0,0);
        };
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("Left");
            transform.Translate(-1,0,0);
        };
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            print("Left");
            transform.Translate(0, 1, 0);
        };
    }
}
