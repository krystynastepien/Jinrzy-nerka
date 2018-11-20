using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InventoryUse : MonoBehaviour {

    public Inventory _Inventory;
    public IInventoryItem Item { get; set; }
 




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
           Debug.Log(" it's item from chest");
           

        }
        
    }

    public void Clicked()
    {

        Transform slot = gameObject.transform.parent;
        Transform inv = slot.transform.parent;
        Transform imageTransform = inv.GetChild(0).GetChild(0).GetChild(0);
        Image image = imageTransform.gameObject.GetComponent<Image>();


        switch (image.sprite.name)
        {
            case "first_aid":
                {
                    IInventoryItem it = new InventoryItemBase();
                    it.Name = "FirstAidKit";
                    _Inventory.AddItemFromChest(it);
                    break;
                }
        }

        Debug.Log(image.sprite.name);
        /*foreach (Transform slot in inventoryPanel)
        {
            
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();

            Debug.Log(image.name);
        }*/
    }
}

