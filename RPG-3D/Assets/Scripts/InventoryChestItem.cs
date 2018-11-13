using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public interface IIChestInventoryItem
{
    string Name { get; }

    Sprite Image { get; }
}


public class InventoryChestEventArgs : EventArgs
{
    public InventoryChestEventArgs(IIChestInventoryItem chest_item)
    {
        ChestItem = chest_item;
    }

    public IIChestInventoryItem ChestItem;

}

