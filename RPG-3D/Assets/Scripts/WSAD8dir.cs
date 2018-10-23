using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSAD8dir : MonoBehaviour {

    public GameObject chara;
    private GameObject enemy;
    private SlopesScript SlopeScr;

    public float velocity = 10;
    public float turnSpeed = 20;

    public bool moving2;
    public Vector3 lastPos;

    Vector2 input;
    float angle;

    Quaternion targetRotation;
    Transform cam;

 
    public Inventory inventory;


    // Use this for initialization
    void Start () {
        cam = Camera.main.transform;
        lastPos = transform.position;
        SlopeScr = chara.GetComponent<SlopesScript>();
    }
	
	// Update is called once per frame
	void Update () {
        GetInput();
        moving2 = false;

        if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;

        CalculateDirection();
        Rotate();
        Move();
        if (lastPos != transform.position)
        {
            moving2 = true;
        }
        lastPos = transform.position;
    }




    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");  //a d
        input.y = Input.GetAxisRaw("Vertical");  // w s
    }

    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y); //to daje radiany
        angle = Mathf.Rad2Deg * angle; //rad2deg to constant value
        angle += cam.eulerAngles.y;
    }



    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed*Time.deltaTime);
    }

    void RotateToClickedEnemy()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Move()
    {
        if (SlopeScr.groundAngle >= SlopeScr.maxGroundAngle) return;
                                                                     // transform.position += transform.forward * velocity * Time.deltaTime;
        transform.position += SlopeScr.forward * velocity * Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        IInventoryItem item = collision.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
            Debug.Log("hit collider");
        }
    }

}
