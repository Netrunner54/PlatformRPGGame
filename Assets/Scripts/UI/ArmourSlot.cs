using UnityEngine;
using UnityEngine.UI;

public class ArmourSlot : MonoBehaviour
{
    public InventoryItems playerInventory;
    public PlayerArmorSystem playerArmourSystem;

    public Item item = null;
    public Image item_Icon;
    public TMPro.TextMeshProUGUI ItemName;
    public string ArmourPart = "Breastplate";

    // Start is called before the first frame update
    void Start()
    {
        GameObject Parent = gameObject.transform.parent.gameObject;
        GameObject Grandparent = Parent.gameObject.transform.parent.gameObject;
        playerArmourSystem = Grandparent.GetComponent<InventorySystem>().playerArmorSystem;
        playerInventory = Grandparent.GetComponent<InventorySystem>().inventory;
    }

    // Update is called once per frame
    void Update()
    {
        item = playerArmourSystem.GetArmorPart(ArmourPart);
        if (item != null)
        {
            item_Icon.sprite = item.ItemIcon;
            item_Icon.color = new Color(255, 255, 255, 255);
        }
        ItemName.text = ArmourPart;
    }

    public void TakeOff()
    {
        if (playerArmourSystem.GetArmorPart(ArmourPart).GetComponent<Item>().usable)
        {
            playerInventory.AddItem(item);
            playerArmourSystem.TakeOff(ArmourPart);
        }

    }
}
