using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{

    public PlayerArmorSystem armorSystem;

    public TMPro.TextMeshProUGUI FireProtection;
    public TMPro.TextMeshProUGUI WaterProtection;
    public TMPro.TextMeshProUGUI DeadMagicProtection;
    public TMPro.TextMeshProUGUI CutProtection;
    public TMPro.TextMeshProUGUI StabProtection;


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
        //fire Protection
        int fireProtection = (int)armorSystem.FireProtection / 2;
        FireProtection.text = "Fire Protection: " + fireProtection.ToString() + "%";
        if (fireProtection > 0) { FireProtection.color = new Color(0, 255, 0, 255); }
        else if (fireProtection < 0) { FireProtection.color = new Color(255, 0, 0, 255); }
        else { FireProtection.color = new Color(255, 255, 255, 255); }


        //water Protection
        int waterProtection = (int)armorSystem.WaterProtection / 2;
        WaterProtection.text = "Water Protection: " + waterProtection.ToString() + "%";
        if (waterProtection > 0) { WaterProtection.color = new Color(0, 255, 0, 255); }
        else if (waterProtection < 0) { WaterProtection.color = new Color(255, 0, 0, 255); }
        else { WaterProtection.color = new Color(255, 255, 255, 255); }


        //dead Magic Protection
        int deadMagicProtection = (int)armorSystem.DeadMagicProtection / 2;
        DeadMagicProtection.text = "Dead Magic Protection: " + deadMagicProtection.ToString() + "%";
        if (deadMagicProtection > 0) { DeadMagicProtection.color = new Color(0, 255, 0, 255); }
        else if (deadMagicProtection < 0) { DeadMagicProtection.color = new Color(255, 0, 0, 255); }
        else { DeadMagicProtection.color = new Color(255, 255, 255, 255); }


        //cut Protection
        int cutProtection = (int)armorSystem.CutProtection / 2;
        CutProtection.text = "Cut Protection: " + cutProtection.ToString() + "%";
        if (cutProtection > 0) { CutProtection.color = new Color(0, 255, 0, 255); }
        else if (cutProtection < 0) { CutProtection.color = new Color(255, 0, 0, 255); }
        else { CutProtection.color = new Color(255, 255, 255, 255); }


        //stab Protection
        int stabProtection = (int)armorSystem.StabProtection / 2;
        StabProtection.text = "Stab Protection: " + stabProtection.ToString() + "%";
        if (stabProtection > 0) { StabProtection.color = new Color(0, 255, 0, 255); }
        else if (stabProtection < 0) { StabProtection.color = new Color(255, 0, 0, 255); }
        else { StabProtection.color = new Color(255, 255, 255, 255); }
    }
}
