using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour {

    public Inventory Inventory; // z Inventory.cs
    public Image[] itTab;
    public Sprite[] spriteTab;
    int a = 0;
    bool kit_istnieje = false;

    IInventoryItem kit;



    // Use this for initialization
    void Start () {
        kit = new FirstAid();
        Inventory.ItemAdded += InventoryScript_ItemAdded;   //EventHandler<InventoryEventArgs> ItemAdded // informuje kiedy item zostanie dodany do inventory
        Inventory.ItemRemoved += InventoryScript_ItemRemoved;
        itTab = new Image[5];
        spriteTab = new Sprite[5];

        Transform inventoryPanelTab = transform.Find("InventoryPanel");
        int h = 0;
        foreach (Transform slot in inventoryPanelTab)
        {
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>(); //
            itTab[h] = image;
            spriteTab[h] = itTab[h].sprite;
            h++;
        }
                //   Debug.Log("inventory initialized"); // uzupelnia inventory jesli trzeba (?)
    }
	


    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {

        for (int i = 0; i < 5; i++)
        {

            if (spriteTab[i].Equals(e.Item.Image))
            {
                Debug.Log("mUSK istnieje juz: " + kit.counter);
                //kit.counter += 1;
                kit_istnieje = true;
                break;
            }
            
        }

        if (!kit_istnieje) {
            Transform inventoryPanel = transform.Find("InventoryPanel"); // InventoryPanel jest w HUD, w nim są sloty

            //Debug.Log("found inventory panel");

            foreach (Transform slot in inventoryPanel)
            {
                //Border--- Image   InventoryPanel->Slot1->Border1->ItemImage1 !!!
                Transform imageTransform = slot.GetChild(0).GetChild(0);
                Image image = imageTransform.GetComponent<Image>(); //Assigns the transform of the first child of the Game Object this script is attached to.
                                                                    //Debug.Log(slot.GetChild(0).GetChild(0).transform.name);



                // Debug.Log(image.name);
                ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();


                if (!image.enabled)
                {
                    //  Debug.Log("image enabled");   //jesli slot jest pusty to jes;i damy enabled to bd biale tlo. wiec jak pusty to musi byc disabled (not active)

                    image.enabled = true;
                    image.sprite = e.Item.Image;
                    itemDragHandler.Item = e.Item;
                    spriteTab[a] = e.Item.Image;
                    a++;
                    kit.counter += 1;

                    break;
                }


                //we found empty slot

            }
        }
        else
        {
            kit.counter += 1;

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
            
            if (itemDragHandler.Item.Name==e.Item.Name) //sprawdzam czy przedmiot ktory jest dragowany to ten sam przedmiot ktory znajduje sie w inventory
            {
               //wyrzucanie przedmiotu z inventory
                    image.enabled = false;
                    image.sprite = null;
                    e.Item = null;
                    //itemDragHandler.Item = null;
                    Debug.Log("arbuz wyczyszczono slot " + slot.name);
                break;
            }
            //break;              
            
        }
    }

}
