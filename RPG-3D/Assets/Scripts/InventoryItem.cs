using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public interface IInventoryItem   //interface, zaczyna sie od I zazwyczaj, np kazdy przedmion (np. apteczka) musi miec własnosc: nazwa, Image i metode OnPickp()
{
    string Name { get;  }   //read only

    Sprite Image { get;  }  //read only

    int counter { get; set; }

    void OnPickup();    // kiedy gracz zbierze rzecz

    void OnDrop();    // kiedy gracz wyrzuci item z inventory


    //InventorySlot Slot { get; set; }

}

public class InventoryEventArgs : EventArgs
{

    public IInventoryItem Item; // obiekt z interface

    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    

}

