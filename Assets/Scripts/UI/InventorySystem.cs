using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public InventoryItems inventory;
    public List<Item> itemsList;
    public Image inventoryBackground;
    public Image SlotIcon;
    public GameObject Slots;

    public GameObject player;

    private List<Slot> slotsList = new List<Slot>();

    public PlayerArmorSystem playerArmorSystem;


    // Start is called before the first frame update
    void Start()
    {
        itemsList = inventory.Items;
        int children = Slots.transform.childCount;
        for (int i = 0; i < children; ++i)
            slotsList.Add(Slots.transform.GetChild(i).GetComponent<Slot>());
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 35; i++)
        {
            slotsList[i].item = itemsList[i];
        }

    }


    public void TakeOnBearstplate(Breastplate newbreastplate)
    {
        Breastplate oldBreastplate = player.GetComponent<PlayerArmorSystem>().breastplate;
        player.GetComponent<InventoryItems>().RemoveItem(newbreastplate.gameObject.GetComponent<Item>());
        if (oldBreastplate.gameObject.name != "DefaultBreastplate(Clone)" && oldBreastplate.gameObject.name != "DefaultBreastplate")
        {
            player.GetComponent<InventoryItems>().AddItem(oldBreastplate.gameObject.GetComponent<Item>());
        }
        oldBreastplate.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        player.GetComponent<PlayerArmorSystem>().breastplate = Instantiate(newbreastplate).GetComponent<Breastplate>();
        player.GetComponent<PlayerArmorSystem>().breastplate.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

    }

    public void TakeOnTrausers(Trausers newTrausers)
    {
        Trausers oldTrausers = player.GetComponent<PlayerArmorSystem>().trausers;
        player.GetComponent<InventoryItems>().RemoveItem(newTrausers.gameObject.GetComponent<Item>());
        if (oldTrausers.gameObject.name != "DefaultTrausers(Clone)" && oldTrausers.gameObject.name != "DefaultTrausers")
        {
            player.GetComponent<InventoryItems>().AddItem(oldTrausers.gameObject.GetComponent<Item>());
        }
        oldTrausers.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        player.GetComponent<PlayerArmorSystem>().trausers = Instantiate(newTrausers).GetComponent<Trausers>();
        player.GetComponent<PlayerArmorSystem>().trausers.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

    }

    public void TakeOnBoots(Boots newBoots)
    {
        Boots oldBoots = player.GetComponent<PlayerArmorSystem>().boots;
        player.GetComponent<InventoryItems>().RemoveItem(newBoots.gameObject.GetComponent<Item>());
        if (oldBoots.gameObject.name != "DefaultBoots(Clone)" && oldBoots.gameObject.name != "DefaultBoots")
        {
            player.GetComponent<InventoryItems>().AddItem(oldBoots.gameObject.GetComponent<Item>());
        }
        oldBoots.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        player.GetComponent<PlayerArmorSystem>().boots = Instantiate(newBoots).GetComponent<Boots>();
        player.GetComponent<PlayerArmorSystem>().boots.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

    }

    public void TakeOnGloves(Gloves newGloves)
    {
        Gloves oldGloves = player.GetComponent<PlayerArmorSystem>().gloves;
        player.GetComponent<InventoryItems>().RemoveItem(newGloves.gameObject.GetComponent<Item>());
        if (oldGloves.gameObject.name != "DefaultGloves(Clone)" && oldGloves.gameObject.name != "DefaultGloves")
        {
            player.GetComponent<InventoryItems>().AddItem(oldGloves.gameObject.GetComponent<Item>());
        }
        oldGloves.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        player.GetComponent<PlayerArmorSystem>().gloves = Instantiate(newGloves).GetComponent<Gloves>();
        player.GetComponent<PlayerArmorSystem>().gloves.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

    }

    public void TakeOnHelmet(Helmet newHelmet)
    {
        Helmet oldHelmet = player.GetComponent<PlayerArmorSystem>().helmet;
        player.GetComponent<InventoryItems>().RemoveItem(newHelmet.gameObject.GetComponent<Item>());
        if (oldHelmet.gameObject.name != "DefaultHelmet(Clone)" && oldHelmet.gameObject.name != "DefaultHelmet")
        {
            player.GetComponent<InventoryItems>().AddItem(oldHelmet.gameObject.GetComponent<Item>());
        }
        oldHelmet.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        player.GetComponent<PlayerArmorSystem>().helmet = Instantiate(newHelmet).GetComponent<Helmet>();
        player.GetComponent<PlayerArmorSystem>().helmet.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

    }
}
