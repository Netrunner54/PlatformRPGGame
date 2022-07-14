using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngreedienSlot : MonoBehaviour
{
    public AlchemySystem alchemy;

    public Item item = null;
    public Image item_Icon;
    public TMPro.TextMeshProUGUI ItemName;

    public int slotNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (item != null)
        {
            item_Icon.sprite = item.ItemIcon;
            item_Icon.color = new Color(255, 255, 255, 255);
            ItemName.text = item.Name;
        }
        else
        {
            item_Icon.color = new Color(255, 255, 255, 0);
            ItemName.text = " ";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (item != null)
        {
            item_Icon.sprite = item.ItemIcon;
            item_Icon.color = new Color(255, 255, 255, 255);
            ItemName.text = item.Name;
        }
        else
        {
            item_Icon.color = new Color(255, 255, 255, 0);
            ItemName.text = " ";
        }
    }

    public void Remove()
    {
        alchemy.RemoveIngreedientFromPotion(slotNumber);
    }
}
