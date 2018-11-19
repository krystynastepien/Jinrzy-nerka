using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearObject : MonoBehaviour
{
    string obiekt_tag;
    private GameObject chara, obiekt;
    RaycastHit clickedInfo;


    // Use this for initialization
    void Start()
    {
        chara = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        /*

        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

            bool didHit = Physics.Raycast(toMouse, out clickedInfo, 500.0f);
            if (didHit)
            {
                Debug.Log("klikenieto na" + clickedInfo.collider.name);
            }
        }
        */
    }





    private void OnTriggerEnter(Collider other)
    {
        obiekt_tag = other.gameObject.tag;
        switch (obiekt_tag)
        {
            case "Door":
                {
                    Debug.Log("postac w poblizu drzwi");
                    obiekt = GameObject.FindGameObjectWithTag("Door");
                    break;
                }

            case "Skrzynia":
                {
                    Debug.Log("postac w poblizu skrzyni");
                    obiekt = GameObject.FindGameObjectWithTag("Skrzynia");
                    break;
                }

            default:
                {
                    Debug.Log("ehh postac nie jest w poblizu niczego");
                    obiekt = null;
                    break;
                }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        obiekt_tag = other.gameObject.tag;
        switch (obiekt_tag)
        {
            case "Door":
                {
                    Debug.Log("postac odeszla od drzwi hlep ");
                    obiekt = null;
                    break;
                }

            case "Skrzynia":
                {
                    Debug.Log("postac odeszla od skrzyni");
                    obiekt = null;
                    break;
                }

            default:
                {
                    Debug.Log("ehh postac nie jest w poblizu niczego");
                    obiekt = null;
                    break;
                }
        }
    }
}


