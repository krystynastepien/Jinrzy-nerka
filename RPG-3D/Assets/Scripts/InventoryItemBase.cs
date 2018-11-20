using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : MonoBehaviour, IInventoryItem {
    private string m_Name;
    private Sprite m_Image;
    public virtual string Name
    {
        get
        {
            return "_base item_";
        }
        
    }

    public Sprite _Image;

    public virtual Sprite Image
    {
        get { return _Image; }
       
    }

    public int c = 0;
    public int counter
    {
        get
        {
            return c;
        }

        set
        {
            c = value;
        }
    }

    public virtual void OnDrop()
    {
        RaycastHit hit = new RaycastHit();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
        //counter -= 1;
    }

    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
        //counter += 1;
    }

}
