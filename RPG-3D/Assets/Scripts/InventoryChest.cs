using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class InventoryChest : MonoBehaviour
{

    private const int SLOTS = 9;

    private List<IIChestInventoryItem> mItems = new List<IIChestInventoryItem>();

    public event EventHandler<InventoryChestEventArgs> ItemAdded;



    public GameObject[] drzwi;

    private string drzwi_name;
    RaycastHit rhInfo;




    // Use this for initialization
    void Start()
    {

    }



    public void AddItem(IIChestInventoryItem item)
    {

        // Debug.Log("available slots, slots taken: " + mItems.Count);
        //  Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

        mItems.Add(item);
        // item.OnPickup();

        if (ItemAdded != null)
        {
            Debug.Log("added itema to chest");
            ItemAdded(this, new InventoryChestEventArgs(item));
        }

    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            switch (rhInfo.collider.name)
            {
                case "chest1":
                    Console.WriteLine("skrzyni1 1");
                    break;
                case "chest2":
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;


            }

            if (Input.GetMouseButtonDown(0))
            {
                Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

                bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);
                if (didHit)
                {
                    Debug.Log("klikenieto na" + rhInfo.collider.name);
                }
            }
        }
    }
}