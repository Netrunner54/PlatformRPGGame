using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item = null;
    public Image item_Icon;
    public TMPro.TextMeshProUGUI ItemName;
    public TMPro.TextMeshProUGUI CountOfItem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (item != null)
        {
            item_Icon.sprite = item.ItemIcon;
            item_Icon.color = new Color(255, 255, 255, 255);
            ItemName.text = item.Name;
            CountOfItem.text = item.Count.ToString();
        }
        else
        {
            item_Icon.color = new Color(255, 255, 255, 0);
            ItemName.text = " ";
            CountOfItem.text = " ";
        }
    }

    public void UseItem()
    {
        if (item != null)
        {
            GameObject ParentObject = gameObject.transform.parent.gameObject;
            GameObject GrandparentObject = ParentObject.transform.parent.gameObject;
            GameObject GreatGrandparentObject = GrandparentObject.transform.parent.gameObject;

            if(item.type == "Alchemy") { try { GreatGrandparentObject.GetComponent<AlchemySystem>().AddIngreedientToPotion(item); } finally { } return; }

            try { item.Use(GreatGrandparentObject.GetComponent<InventorySystem>(), GreatGrandparentObject.GetComponent<InventorySystem>().player); }
            finally { }
        }

    }
}