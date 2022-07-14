using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItems : MonoBehaviour
{
    public int maxItemsCount = 35;
    public List<Item> Items = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item item) {
        for (int i = 0; i < 35; i++)
        {
            if (Items[i] == item)
            {
                if (item.Count + 1 <= item.maxCount)
                {
                    item.Count++;
                    return;
                }
            }
        }

        for (int i = 0; i < 35; i++) 
        { 
            if (Items[i] == null) 
            { 
                Items[i] = item; 
                break; 
            } 
        } 
    }

    public void RemoveItem(Item item) 
    {
        for (int i = 0; i < 35; i++)
        {
            if (Items[i] == item)
            {
                if (item.Count - 1 > 0)
                {
                    item.Count--;
                    return;
                }
            }
        }

        for (int i = 0; i < 35; i++)
        {
            if (Items[i] == item)
            {
                Items[i] = null;
                return;
            }
        }
    }

}
