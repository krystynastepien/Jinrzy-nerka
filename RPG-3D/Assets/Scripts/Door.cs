using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public GameObject[] drzwi;
    private GameObject chara;
    private bool touched;
    private string drzwi_name;
    RaycastHit rhInfo;


    // Use this for initialization
    void Start () {

        drzwi = GameObject.FindGameObjectsWithTag("Door");
        chara = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            if (touched)
            {
                if(drzwi_name == "drzwi_test1" && rhInfo.collider.name == "drzwi_test1")
                {
                    
                    SceneManager.LoadSceneAsync("scene7room");
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);
            if (didHit)
            {
                Debug.Log("klikenieto na"+rhInfo.collider.name);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touched = true;
            drzwi_name = this.name;
            Debug.Log("drzwi in" + drzwi_name);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("drzwi out");
            touched = false;
        }
    }

}
