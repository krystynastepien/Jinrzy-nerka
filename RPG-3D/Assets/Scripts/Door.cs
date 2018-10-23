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
                if(drzwi_name == "drzwi_test1")
                {
                    SceneManager.LoadSceneAsync("scene7room");
                }
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
