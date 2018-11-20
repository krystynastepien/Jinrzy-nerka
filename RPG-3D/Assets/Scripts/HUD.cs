using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour {

    public Inventory Inventory; // z Inventory.cs

	// Use this for initialization
	void Start () {
        Inventory.ItemAdded += InventoryScript_ItemAdded;   //EventHandler<InventoryEventArgs> ItemAdded // informuje kiedy item zostanie dodany do inventory
        Inventory.ItemRemoved += InventoryScript_ItemRemoved;
     //   Debug.Log("inventory initialized"); // uzupelnia inventory jesli trzeba (?)
	}
	


    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel"); // InventoryPanel jest w HUD, w nim są sloty

        //Debug.Log("found inventory panel");

        foreach(Transform slot in inventoryPanel)
        {
            //Border--- Image   InventoryPanel->Slot1->Border1->ItemImage1 !!!
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>(); //Assigns the transform of the first child of the Game Object this script is attached to.
                                                                //Debug.Log(slot.GetChild(0).GetChild(0).transform.name);

            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();


           
            
        
                
                
                    if (!image.enabled)
                    {
                        //  Debug.Log("image enabled");   //jesli slot jest pusty to jes;i damy enabled to bd biale tlo. wiec jak pusty to musi byc disabled (not active)

                        image.enabled = true;
                        image.sprite = e.Item.Image;
                        itemDragHandler.Item = e.Item;
                       


                        break;
                    }
                

            //we found empty slot
            
        }
    }





    private void InventoryScript_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel"); // InventoryPanel jest w HUD, w nim są sloty

        //Debug.Log("found inventory panel");

        foreach (Transform slot in inventoryPanel)
        {
            //Border--- Image   InventoryPanel->Slot1->Border1->ItemImage1 !!!
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>(); //Assigns the transform of the first child of the Game Object this script is attached to.
                                                                //Debug.Log(slot.GetChild(0).GetChild(0).transform.name);

          
                               
                ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            //we found item in the inventory/ UI
            
                if (itemDragHandler.Item.Equals(e.Item))
                {
                    //  Debug.Log("image disabled");   

                    image.enabled = false;
                    image.sprite = null;
                    itemDragHandler.Item = null;
                   


                    break;
                }
            



                
            
        }
    }

}
