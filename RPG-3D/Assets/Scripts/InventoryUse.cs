using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InventoryUse : MonoBehaviour {

    public Inventory _Inventory;
    public IInventoryItem Item { get; set; }
    public Sprite aid_image;

    GameObject aidItem;
    IInventoryItem iaidItem;
 




    public void OnItemClicked()
    {
        ItemDragHandler dragHandler = gameObject.transform.Find("ItemImage").GetComponent<ItemDragHandler>();

        Transform slot = gameObject.transform.parent;
        Transform inv = slot.transform.parent;
        string inv_name = inv.gameObject.name;

        


        if (inv_name == "InventoryPanel") // sprawdza w jakim inventory kliknieto: main hud
        {
            IInventoryItem item = dragHandler.Item;
            Debug.Log(item.Name + " from " + inv.gameObject.name);
            
            _Inventory.UseItem(item);           
        }
        else if(inv_name == "Inventory_Chest") // sprawdza w jakim inventory kliknieto: chest
        {
            Transform imageTransform = inv.GetChild(0).GetChild(0).GetChild(0);
            Image image = imageTransform.gameObject.GetComponent<Image>();

            aidItem = GameObject.FindGameObjectWithTag("AidItem");
            iaidItem = aidItem.GetComponent<IInventoryItem>();

            switch (image.sprite.name)
            {
                case "first_aid":
                    {
                        _Inventory.AddItemFromChest(iaidItem);
                        //Debug.Log(iaidItem.Name+"    "+iaidItem.Image.name);
                        //image = null;
                        break;
                    }
            }

            

        }       
    }
}

