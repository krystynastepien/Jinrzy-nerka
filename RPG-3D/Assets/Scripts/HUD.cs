using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour {

    public Inventory Inventory;

	// Use this for initialization
	void Start () {
            Inventory.ItemAdded += InventoryScript_ItemAdded;
        Debug.Log("inventory initialized");
	}
	
    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        Debug.Log("found inventory panel");
        foreach(Transform slot in inventoryPanel)
        {
            //Border--- Image
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            //Debug.Log(slot.GetChild(0).GetChild(0).transform.name);
            
            //we found empty slot
            if (!image.enabled)
            {
                Debug.Log("image enabled");
                image.enabled = true;
                image.sprite = e.Item.Image;

                break;
            }
        }
    }
}
