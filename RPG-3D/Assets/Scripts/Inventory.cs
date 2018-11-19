using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Inventory : MonoBehaviour {

    private const int SLOTS = 5; // 5 miejsc dla podręcznego inventory

    private List<IInventoryItem> mItems = new List<IInventoryItem>();    // lista obiektow z inventry interface (name, sprite, onPickup() )

    public event EventHandler<InventoryEventArgs> ItemAdded;   // InvenotryItem.cs -> class InventoryEventArgs  public InventoryEventArgs(IInventoryItem item)
                                                                //{ Item = item;}    event


    public void AddItem(IInventoryItem item) //funckja dodaje obiekt z interface
    {
        if(mItems.Count < SLOTS) // jezeli w tymczasowym inventory jest wystarczajaca ilosc miejsca (tzn mItems to sa te w inventory)
        {
            Debug.Log("there are available slots. sSlots taken: " + mItems.Count);
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                Debug.Log("collider enabled, disabling it");
                collider.enabled = false;
                mItems.Add(item); //dodano do listy inventory
                item.OnPickup();   // w zaleznosci jaką funkcje OnPickup ma konkretny item

                if(ItemAdded != null)  //event
                {
                    Debug.Log("adds item");
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }

    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
