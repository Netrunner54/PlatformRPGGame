using UnityEngine;
using UnityEngine.UI;

public class PlayerWithArmour : MonoBehaviour
{

    public PlayerArmorSystem armorSystem;

    public Image breastplate;
    public Image trausers;
    public Image boots;
    public Image helmet;
    public Image gloves;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Parent = gameObject.transform.parent.gameObject;
        GameObject Grandparent = Parent.gameObject.transform.parent.gameObject;
        armorSystem = Grandparent.GetComponent<InventorySystem>().playerArmorSystem;
    }

    // Update is called once per frame
    void Update()
    {
        breastplate.sprite = armorSystem.breastplate.gameObject.GetComponent<Item>().ItemIcon;
        trausers.sprite = armorSystem.trausers.gameObject.GetComponent<Item>().ItemIcon;
        boots.sprite = armorSystem.boots.gameObject.GetComponent<Item>().ItemIcon;
        helmet.sprite = armorSystem.helmet.gameObject.GetComponent<Item>().ItemIcon;
    }
}
