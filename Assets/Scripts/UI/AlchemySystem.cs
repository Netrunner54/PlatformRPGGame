using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemySystem : MonoBehaviour
{
    public AlchemicalIngreedients Ingreedients;
    public List<Item> ingreediensList = new List<Item>();
    public GameObject Slots;
    public GameObject player;

    private List<Slot> slotsList = new List<Slot>();

    public IngreedienSlot IngreedientSlot0;
    public IngreedienSlot IngreedientSlot1;
    public IngreedienSlot IngreedientSlot2;

    public Slot potionSlot;

    private Potion potionPossibleToCreate;


    public List<Potion> Potions = new List<Potion>();
    

    // Start is called before the first frame update
    void Start()
    {
        ingreediensList = Ingreedients.Items;
        int children = Slots.transform.childCount;
        for (int i = 0; i < children; ++i)
            slotsList.Add(Slots.transform.GetChild(i).GetComponent<Slot>());
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 35; i++)
        {
            slotsList[i].item = ingreediensList[i];
        }

        List<string> ingreedients = new List<string>();
        if (IngreedientSlot0.item != null) { ingreedients.Add(IngreedientSlot0.item.Name); } else { ingreedients.Add("Empty"); }
        if (IngreedientSlot1.item != null) { ingreedients.Add(IngreedientSlot1.item.Name); } else { ingreedients.Add("Empty"); }
        if (IngreedientSlot2.item != null) { ingreedients.Add(IngreedientSlot2.item.Name); } else { ingreedients.Add("Empty"); }
        foreach (Potion potion in Potions)
        {
            if (isPossibleToCreate(potion, ingreedients))
            {
                potionSlot.item = potion.gameObject.GetComponent<Item>();
                potionSlot.item_Icon.color = new Color(255, 255, 255, 255);
                potionPossibleToCreate = potion;

            }
        }
    }

    public void AddIngreedientToPotion(Item ingreedient)
    {
        Ingreedients.RemoveItem(ingreedient);
        if (IngreedientSlot0.item == null) { IngreedientSlot0.item = ingreedient; }
        else if (IngreedientSlot1.item == null) { IngreedientSlot1.item = ingreedient; }
        else if (IngreedientSlot2.item == null) { IngreedientSlot2.item = ingreedient; }
    }

    public void RemoveIngreedientFromPotion(int slotNumber)
    {
        if (slotNumber == 0) { Ingreedients.AddItem(IngreedientSlot0.item); IngreedientSlot0.item = null; }
        if (slotNumber == 1) { Ingreedients.AddItem(IngreedientSlot1.item); IngreedientSlot1.item = null; }
        if (slotNumber == 2) { Ingreedients.AddItem(IngreedientSlot2.item); IngreedientSlot2.item = null; }
    }

    private bool isPossibleToCreate(Potion potion, List<string> ingreedients)
    {
        if (potion.ingreedients[0] == ingreedients[0] || potion.ingreedients[0] == ingreedients[1] || potion.ingreedients[0] == ingreedients[2])
        {
            if (potion.ingreedients[1] == ingreedients[0] || potion.ingreedients[1] == ingreedients[1] || potion.ingreedients[1] == ingreedients[2])
            {
                if (potion.ingreedients[2] == ingreedients[0] || potion.ingreedients[2] == ingreedients[1] || potion.ingreedients[2] == ingreedients[2])
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        else { return false; }   
    }

    public void CreatePotion()
    {
        if (potionPossibleToCreate != null)
        {
            player.GetComponent<InventoryItems>().AddItem(potionPossibleToCreate.gameObject.GetComponent<Item>());
            IngreedientSlot0.item.Count--;
            IngreedientSlot1.item.Count--;
            IngreedientSlot2.item.Count--;
            if (IngreedientSlot0.item.Count <= 0) { IngreedientSlot0.item = null; }
            if (IngreedientSlot1.item.Count <= 0) { IngreedientSlot1.item = null; }
            if (IngreedientSlot2.item.Count <= 0) { IngreedientSlot2.item = null; }
            potionPossibleToCreate = null;
            potionSlot.item = null;
        }
    }
}
