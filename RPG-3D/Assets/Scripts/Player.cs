using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Variables
    public float movementSpeed = 1;
    private float hitDistance = 0.0f;  //y, czyli zawsze bd na ziemi bo tam jest teren
    private bool moving;
    public GameObject PlayerMovePoint;
    private Transform PMP;
    private bool pmpSpawned;
    private GameObject triggeringPMP;




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //player movement
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        //Terrain playerTerrain = new Terrain();

        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

        if (playerPlane.Raycast(ray, out hitDistance))  //jeśli playerplane jest uderzony przez ray na ekranie gry
        {
            Vector3 mouseClickPosition = ray.GetPoint(hitDistance);
            Quaternion targetRotation = Quaternion.LookRotation(mouseClickPosition - transform.position);

            if (Input.GetMouseButtonDown(0))
            {
                moving = true;

                if (pmpSpawned)
                {
                    //PMP = null;
                    PMP.transform.position = mouseClickPosition;
                   // PMP = Instantiate(PlayerMovePoint.transform, mouseClickPosition, Quaternion.identity);
                }
                else
                {
                    PMP = Instantiate(PlayerMovePoint.transform, mouseClickPosition, Quaternion.identity);
                }
                // print(mouseClickPosition);
            }

            if (PMP)
            {
                pmpSpawned = true;
            }
            else
            {
                pmpSpawned = false;
            }

            if (moving)
            {
                Move();
            } 
        }
    }

    public void Move()
    {
        if (PMP)
        {
            transform.position = Vector3.MoveTowards(transform.position, PMP.transform.position, movementSpeed);
            this.transform.LookAt(PMP.transform);
        }
    }

/*
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PMP")
        {
            triggeringPMP = other.gameObject;
            triggeringPMP.GetComponent<PMP>().DestroyPMP();
        }
    }
*/
}
