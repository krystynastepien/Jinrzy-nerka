using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsaokaAnimController : MonoBehaviour {

    public GameObject chara;

    static Animator anim;

    private PlayerScript playerScr;
    private WSAD8dir WSADscr;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        playerScr = chara.GetComponent<PlayerScript>();
        WSADscr = chara.GetComponent<WSAD8dir>();

    }
	
	// Update is called once per frame
	void Update () {
       
        if( WSADscr.moving2 == true) // jesli sie ruszamy po horizontal albo vertical  // playerScr.moving == true 
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }
}
