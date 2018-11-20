using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class NearObject : MonoBehaviour
{
    string obiekt_tag;
    private GameObject chara, obiekt;
    RaycastHit clickedInfo;  

    bool near_door, near_chest;
    private GameObject chest_hud;
    private Transform chest_hud_child;
    private Image[] chest_inv_slots;
    public Sprite aidSprite, bulletSprite, appleSprite;

    private List<IInventoryItem> Itemslist = new List<IInventoryItem>();   // lista obiektow z inventry interface (name, sprite, onPickup() )
    public event EventHandler<InventoryEventArgs> ItemAdded;       //{ Item = item;}    event

    // Use this for initialization
    void Start()
    {
        chara = GameObject.FindGameObjectWithTag("Player");
        near_door = false;
        near_chest = false;

        chest_hud = GameObject.Find("HUD_Chest");
        chest_hud_child = chest_hud.transform.Find("Inventory_Chest");

        chest_inv_slots = new Image[9];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

            bool didHit = Physics.Raycast(toMouse, out clickedInfo, 500.0f);

            if (didHit)
            {
              //  Debug.Log("klikenieto na" + clickedInfo.collider.name);
            }

            if (near_door)
            {
                switch (clickedInfo.collider.name)
                {
                    case "drzwi_test1":
                        {
                           // Debug.Log("zmiana sceny");
                            SceneManager.LoadSceneAsync("scene7room");
                            break;
                        }

                    case "drzwi_test2":
                        {
                          //  Debug.Log("Te drzwi są zablokowane");
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
            else if (near_chest)
            {
                switch (clickedInfo.collider.name)
                {
                    case "Chest1":
                        {
                          //  Debug.Log("skrzynia z aidkit");
                            chest_hud_child.gameObject.SetActive(true);

                            int i = 0;
                            Transform[] tab = new Transform[9];

                            //---wyszukiwanie images do item z
                            foreach (Transform slot in chest_hud_child)
                            {
                                // Debug.Log(slot.gameObject.name); //Slot
                                chest_inv_slots[i] = slot.GetChild(0).GetChild(0).GetComponent<Image>();//Assigns the transform of the first child of the Game Object this script is attached to.
                                chest_inv_slots[i].enabled = false;
                                i++;                                                  //Debug.Log(slot.GetChild(0).GetChild(0).transform.name);

                                
                                //chest_inv_slots[0].enabled = true;
                                //image.sprite = aidSprite;
                               // break;
                            }
                            chest_inv_slots[0].enabled = true;
                            chest_inv_slots[0].sprite = aidSprite;

                            chest_inv_slots[1].enabled = true;
                            chest_inv_slots[1].sprite = appleSprite;
                            break;
                        }

                    case "Chest2":
                        {
                          //  Debug.Log("skrzynia z bullets");
                            chest_hud_child.gameObject.SetActive(true);

                            int i = 0;
                            //---wyszukiwanie images do item z
                            foreach (Transform slot in chest_hud_child)
                            {
                                //Border--- Image   Chest->Slot1->ItemImage1 !!!
                                chest_inv_slots[i] = slot.GetChild(0).GetChild(0).GetComponent<Image>(); //Assigns the transform of the first child of the Game Object this script is attached to.
                                chest_inv_slots[i].enabled = false;
                                i++;

                            }
                            chest_inv_slots[0].enabled = true;
                            chest_inv_slots[0].sprite = bulletSprite;
                            break;
                        }//-------------------------------

                    default:
                        {

                            break;
                        }
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        obiekt_tag = other.gameObject.tag;
        switch (obiekt_tag)
        {
            case "Door":
                {
                   // Debug.Log("postac w poblizu drzwi");
                    obiekt = GameObject.FindGameObjectWithTag("Door");
                    near_door = true;
                    break;
                }

            case "Skrzynia":
                {
                  //  Debug.Log("postac w poblizu skrzyni");
                    obiekt = GameObject.FindGameObjectWithTag("Skrzynia");
                    near_chest = true;
                    break;
                }

            default:
                {
                   // Debug.Log("ehh postac nie jest w poblizu niczego");
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
                   // Debug.Log("postac odeszla od drzwi hlep ");
                    obiekt = null;
                    near_door = false;
                    break;
                }

            case "Skrzynia":
                {
                   // Debug.Log("postac odeszla od skrzyni");
                    obiekt = null;
                    near_chest = false;
                    chest_hud_child.gameObject.SetActive(false);

                    break;
                }

            default:
                {
                  //  Debug.Log("ehh postac nie jest w poblizu niczego");
                    obiekt = null;
                    break;
                }
        }
    }






}