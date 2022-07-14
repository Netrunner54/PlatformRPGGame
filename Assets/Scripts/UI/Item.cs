using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public string Name;
    public Sprite ItemIcon;
    public string type;
    public string exactType;
    public int Count = 1;
    public int maxCount = 1;
    public bool usable = false;
    public string function;

    public void Use(InventorySystem inventorySystem, GameObject player)
    {
        if (usable)
        {
            Debug.Log("usable");
            if (function == "Eat")
            {
                Debug.Log("Eat");
            }

            if (function == "Wear")
            {
                Debug.Log("Wear");
                if (exactType == "Breastplate") { inventorySystem.TakeOnBearstplate(gameObject.GetComponent<Breastplate>()); }
                if (exactType == "Trausers") { inventorySystem.TakeOnTrausers(gameObject.GetComponent<Trausers>()); }
                if (exactType == "Boots") { inventorySystem.TakeOnBoots(gameObject.GetComponent<Boots>()); }
                if (exactType == "Gloves") { inventorySystem.TakeOnGloves(gameObject.GetComponent<Gloves>()); }
                if (exactType == "Helmet") { inventorySystem.TakeOnHelmet(gameObject.GetComponent<Helmet>()); }
            }
        }

    }

    private void Update()
    {
        if (Count <= 0) { Destroy(gameObject); }
    }
}
