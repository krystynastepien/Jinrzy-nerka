using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public interface IInventoryItem   //interface, zaczyna sie od I zazwyczaj
{
    string Name { get; }   //read only

    Sprite Image { get; }  //read only

    void OnPickup();
}

public class InventoryEventArgs : EventArgs
{

    public IInventoryItem Item; // obiekt z interface

    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    

}

