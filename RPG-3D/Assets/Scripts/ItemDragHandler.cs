using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// ten skrypt należy wrzucic do każdego ItemImage w Slotach w inventory!!!!!!!!!!!1

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler { //musimy zaimplementowac metode onDrag z interfaceu  IDragHandler (w UnityEngine.EventSystems)
    //IEndDragHandler informuje nas kiedy przenoszenie zostało ukonczone
 
    public IInventoryItem Item { get; set; }   // referencja do IInventoryItem


    public void OnDrag(PointerEventData eventData)
    {
        // 1. bierzemy pozycje kursora
        transform.position = Input.mousePosition; 
       //------------------ do tego momentu ikona tylko wroci na miejsce

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //1. reset the position of ItemImage
        transform.localPosition = Vector3.zero;
        //------------------ do tego momentu ikona tylko wroci na miejsce

    }

}
