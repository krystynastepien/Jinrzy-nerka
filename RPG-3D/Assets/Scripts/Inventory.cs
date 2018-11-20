using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Inventory : MonoBehaviour {

    private const int SLOTS = 5; // 5 miejsc dla podręcznego inventory

    private List<IInventoryItem> mItems = new List<IInventoryItem>();    // lista obiektow z inventry interface (name, sprite, onPickup() )

    //metoda ktora dodaje item do listy mItems
    public event EventHandler<InventoryEventArgs> ItemAdded;   // InvenotryItem.cs -> class InventoryEventArgs  public InventoryEventArgs(IInventoryItem item)
                                                               //{ Item = item;}    event
    public event EventHandler<InventoryEventArgs> ItemRemoved;   //event

    public event EventHandler<InventoryEventArgs> ItemUsed;   //event





    internal void UseItem(IInventoryItem item)
    {
        if (ItemUsed != null)
        {
            ItemUsed(this, new InventoryEventArgs(item));   //itemUsed jest puszczony
            RemoveItem(item);
        }
       
        
       
    }



    public void AddItem(IInventoryItem item) //funckja dodaje obiekt z interface
    {
      
        
            if (mItems.Count < SLOTS) // jezeli w tymczasowym inventory jest wystarczajaca ilosc miejsca (tzn mItems to sa te w inventory), wtedy dodajemy item
            {
                // Debug.Log("there are available slots. sSlots taken: " + mItems.Count);
                item.counter = 1;
                Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
                if (collider.enabled)
                {
                    //  Debug.Log("collider enabled, disabling it");
                    collider.enabled = false;

                    mItems.Add(item); //dodano do listy inventory

                    item.OnPickup();   // w zaleznosci jaką funkcje OnPickup ma konkretny item

                    if (ItemAdded != null)  //event
                    {
                        ItemAdded(this, new InventoryEventArgs(item));
                    }
                }
            }
        

    }


    public void AddItemFromChest(IInventoryItem item) //funckja dodaje obiekt z interface
    {
        if (mItems.Count < SLOTS) // jezeli w tymczasowym inventory jest wystarczajaca ilosc miejsca (tzn mItems to sa te w inventory), wtedy dodajemy item
        {
                mItems.Add(item); //dodano do listy inventory
            

            if (ItemAdded != null)  //event
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            
        }

    }





    public void RemoveItem(IInventoryItem item) //funckja dodaje obiekt z interface
    {
        if (mItems.Contains(item)) // jezeli w tymczasowym inventory jest wystarczajaca ilosc miejsca (tzn mItems to sa te w inventory), wtedy dodajemy item
        {
            mItems.Remove(item);  // usuniety z listy obiektow

            item.OnDrop(); //onDrop z danego itemu

            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            if(collider != null)
            {
                //collider.enabled = true;  // reaktywowanie collidera
                collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            
            if(ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item));   //itemRemoved jest puszczony
            }
        }

    }

}
