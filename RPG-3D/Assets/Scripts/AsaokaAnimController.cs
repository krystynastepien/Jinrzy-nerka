using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsaokaAnimController : MonoBehaviour {

    public GameObject chara;

    static Animator anim;

    private PlayerScript playerScr;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        playerScr = chara.GetComponent<PlayerScript>();
     
    }
	
	// Update is called once per frame
	void Update () {
       
        if(playerScr.moving == true) // jesli sie ruszamy po horizontal albo vertical
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }
}
