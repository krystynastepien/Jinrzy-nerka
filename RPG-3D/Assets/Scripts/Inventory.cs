using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Inventory : MonoBehaviour {

    private const int SLOTS = 5;

    private List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public void AddItem(IInventoryItem item)
    {
        if(mItems.Count < SLOTS)
        {
            Debug.Log("available slots, slots taken: " + mItems.Count);
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                Debug.Log("collider enabled, disabling it");
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickup();

                if(ItemAdded != null)
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
