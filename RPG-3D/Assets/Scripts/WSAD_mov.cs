using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSAD_mov : MonoBehaviour {


    public float velocity = 2;
    public float turnSpeed = 10;

    Vector2 input;
    float angle;


    Quaternion targetRotation;
    Transform cam;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();

        if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y)<1) { return; }

        CalcDirection();
        Rotate();
        Move();
	}


    // input horizontal a, d   and vertical w, s 
void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");  //a,d
        input.y = Input.GetAxisRaw("Vertical");  // w,s
    }


   void CalcDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);  //radiany
        angle = Mathf.Rad2Deg * angle;  //rad2deg to stala wartosc, nie funkcja
       // angle += cam.eulerAngles.y;
    }
   void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime); //current, target, how fast

    }


    void Move()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
    }

}
