using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    public GameObject[] drzwi;
    public GameObject[] skrzynia;
    private GameObject chara, chest_hud;
    private bool touched;
    private string drzwi_name, skrzynia_name;
    RaycastHit rhInfo;


    // Use this for initialization
    void Start () {
        chest_hud = GameObject.Find("HUD_Chest");
        drzwi = GameObject.FindGameObjectsWithTag("Door");
        chara = GameObject.FindGameObjectWithTag("Player");
        skrzynia = GameObject.FindGameObjectsWithTag("Skrzynia");
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
                else if (rhInfo.collider.name == "Chest1")
                {
                    chest_hud.SetActive(true);
                    Debug.Log("otwarto skrzynie Chest1");
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
