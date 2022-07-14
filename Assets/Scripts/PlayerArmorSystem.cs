using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmorSystem : MonoBehaviour
{

    public Breastplate breastplate;
    public Trausers trausers;
    public Boots boots;
    public Gloves gloves;
    public Helmet helmet;

    private string PlayerDirection;

    private float correct = 0;

    public float FireProtection = 0;
    public float WaterProtection = 0;
    public float DeadMagicProtection = 0;
    public float StabProtection = 0;
    public float CutProtection = 0;


    public float FireMagic = 0;
    public float WaterMagic = 0;
    public float DeadMagic = 0;
    public float CutDamge = 0;
    public float StabDamge = 0;

    public Breastplate defaultBreastplate;
    public Trausers defaultTrausers;
    public Boots defaultBoots;
    public Gloves defaultGloves;
    public Helmet defaultHelmet;


    // Start is called before the first frame update
    void Start()
    {
        PlayerDirection = gameObject.GetComponent<PlayerController>().lookingSide;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDirection = gameObject.GetComponent<PlayerController>().lookingSide;
        if (PlayerDirection == "Right") { correct = 0; }
        else if (PlayerDirection == "Left") { correct = 0.0625f; }

        breastplate.transform.position = gameObject.transform.position - new Vector3(correct, 0, 0);
        breastplate.direction = PlayerDirection;

        trausers.transform.position = gameObject.transform.position - new Vector3(correct, 0, 0);
        trausers.direction = PlayerDirection;

        boots.transform.position = gameObject.transform.position - new Vector3(correct, 0, 0);
        boots.direction = PlayerDirection;

        gloves.transform.position = gameObject.transform.position - new Vector3(correct, 0, 0);
        gloves.direction = PlayerDirection;

        helmet.transform.position = gameObject.transform.position - new Vector3(correct, 0, 0);
        helmet.direction = PlayerDirection;


        Bonuses();
    }

    void Bonuses()
    {
        FireProtection = 0;
        FireProtection += breastplate.FireProtection;
        FireProtection += trausers.FireProtection;
        FireProtection += boots.FireProtection;
        FireProtection += helmet.FireProtection;
        FireProtection += gloves.FireProtection;

        WaterProtection = 0;
        WaterProtection += breastplate.WaterProtection;
        WaterProtection += trausers.WaterProtection;
        WaterProtection += boots.WaterProtection;
        WaterProtection += helmet.WaterProtection;
        WaterProtection += gloves.WaterProtection;

        DeadMagicProtection = 0;
        DeadMagicProtection += breastplate.DeadMagicProtection;
        DeadMagicProtection += trausers.DeadMagicProtection;
        DeadMagicProtection += boots.DeadMagicProtection;
        DeadMagicProtection += helmet.DeadMagicProtection;
        DeadMagicProtection += gloves.DeadMagicProtection;

        CutProtection = 0;
        CutProtection += breastplate.CutProtection;
        CutProtection += trausers.CutProtection;
        CutProtection += boots.CutProtection;
        CutProtection += helmet.CutProtection;
        CutProtection += gloves.CutProtection;

        StabProtection = 0;
        StabProtection += breastplate.StabProtection;
        StabProtection += trausers.StabProtection;
        StabProtection += boots.StabProtection;
        StabProtection += helmet.StabProtection;
        StabProtection += gloves.StabProtection;
    }





    public void TakeOff(string ArmorPart)
    {
        if (ArmorPart == "Breastplate") { breastplate.transform.position = new Vector3(-200f, -200f, 0);  breastplate = Instantiate(defaultBreastplate);}
        else if (ArmorPart == "Trausers") { trausers.transform.position = new Vector3(-200f, -200f, 0); trausers = Instantiate(defaultTrausers); }
        else if (ArmorPart == "Boots") { boots.transform.position = new Vector3(-200f, -200f, 0); boots = Instantiate(defaultBoots); }
        else if (ArmorPart == "Gloves") { gloves.transform.position = new Vector3(-200f, -200f, 0); gloves = Instantiate(defaultGloves); }
        else if (ArmorPart == "Helmet") { helmet.transform.position = new Vector3(-200f, -200f, 0); helmet = Instantiate(defaultHelmet); }
    }

    public Item GetArmorPart(string ArmorPart)
    {
        if (ArmorPart == "Breastplate") { return breastplate.GetComponent<Item>(); }
        else if (ArmorPart == "Trausers") { return trausers.GetComponent<Item>(); }
        else if (ArmorPart == "Boots") { return boots.GetComponent<Item>(); }
        else if (ArmorPart == "Gloves") { return gloves.GetComponent<Item>(); }
        else if (ArmorPart == "Helmet") { return helmet.GetComponent<Item>(); }

        else { return null; }
    }
}
