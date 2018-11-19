using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour {

    public Inventory Inventory; // z Inventory.cs

	// Use this for initialization
	void Start () {
        Inventory.ItemAdded += InventoryScript_ItemAdded;   //EventHandler<InventoryEventArgs> ItemAdded
        Debug.Log("inventory initialized"); // uzupelnia inventory jesli trzeba (?)
	}
	


    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel"); // InventoryPanel jest w HUD, w nim są sloty
        Debug.Log("found inventory panel");
        foreach(Transform slot in inventoryPanel)
        {
            //Border--- Image   InventoryPanel->Slot1->Border1->ItemImage1 !!!
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>(); //Assigns the transform of the first child of the Game Object this script is attached to.
            //Debug.Log(slot.GetChild(0).GetChild(0).transform.name);
            
            //we found empty slot
            if (!image.enabled)
            {
                Debug.Log("image enabled");   //jesli slot jest pusty to jes;i damy enabled to bd biale tlo. wiec jak pusty to musi byc disabled (not active)

                image.enabled = true;
                image.sprite = e.Item.Image;

                break;
            }
        }
    }
}
