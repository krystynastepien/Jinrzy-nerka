using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnim : MonoBehaviour {


    private Animator anim;
    private float vert;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        GameObject asaoka = GameObject.Find("asaoka");
        Player playerScript = asaoka.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        vert = Input.GetAxis("Vertical");
        if (playerScript.moving==true) {
            anim.SetFloat("Walking", vert);
        }
    }
}
