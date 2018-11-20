using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// ten skrypt należy wrzucic do każdego ItemImage w Slotach w inventory!!!!!!!!!!!1


public class ItemDropHandler : MonoBehaviour, IDropHandler { //implementujemy OnDrop metode

    public Inventory _Inventory;

    public void OnDrop(PointerEventData eventData)
    {
        //musimy sprawdzic czy item został puszczony poza inventory panel

        //1. pobieram panel inventory
        RectTransform invPanel = transform as RectTransform;   //pozition, size, anchor and pivot info of a Rectangle

        //2. sprawdzamy czy pozycja myszy jest w środku inventory panel. jesli nie to remove from inventory
        if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))  /// !           ???
        {
            //Debug.Log("Drop Item !!!");
            IInventoryItem item = eventData.pointerDrag.gameObject.GetComponent<ItemDragHandler>().Item;
            if (item != null)
            {
                _Inventory.RemoveItem(item);
                item.OnDrop();
            }
        }
    }

   
}
