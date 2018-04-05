using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadOnImpact : MonoBehaviour {

    // Use this for initialization
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.name == "Dead") {
            print("You Died");
            //transform.position = new Vector3(-1.14f, 0.86f, 0.0f);
            SceneManager.LoadScene("Menu");
        }
    }
}
