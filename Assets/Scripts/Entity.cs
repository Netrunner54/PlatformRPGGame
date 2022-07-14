using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour
{
    public GameObject player;

    public float Health = 100;
    public float maxHealth = 100;
    public float HealthRegeneration = 1.5f;
    public float Mana = 50;
    public float maxMana = 50;
    public float ManaRegeneration = 2;


    public float FireMagic = 0;
    public float WaterMagic = 0;
    public float DeadMagic = 0;
    public float CutDamge = 0;
    public float StabDamge = 0;

    public float FireProtection = 0;
    public float DefaultFireProtection = 0;
    public float WaterProtection = 0;
    public float DefaultWaterProtection = 0;
    public float DeadMagicProtection = 0;
    public float DefaultDeadMagicProtection = 0;
    public float StabProtection = 0;
    public float DefaultfStabProtection = 0;
    public float CutProtection = 0;
    public float DefaultCutProtection = 0;



    public PlayerArmorSystem Armour;
    public Loot loot;
    public List<Item> DropItems = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Player")
        {
            FireProtection = DefaultFireProtection + Armour.FireProtection;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < maxHealth) { Health += HealthRegeneration * Time.deltaTime; }
        if (Mana < maxMana) { Mana += ManaRegeneration * Time.deltaTime; }
        //Debug.Log(Health);

        if (Health <= 0) 
        {
            Die(); 
        }

        FireProtection = DefaultFireProtection;
        WaterProtection = DefaultWaterProtection;
        DeadMagicProtection = DefaultDeadMagicProtection;
        CutProtection = DefaultCutProtection;
        StabProtection = DefaultfStabProtection;


        if (gameObject.name == "Player")
        {
            FireProtection = DefaultFireProtection + Armour.FireProtection;
            WaterProtection = DefaultWaterProtection + Armour.WaterProtection;
            DeadMagicProtection = DefaultDeadMagicProtection + Armour.DeadMagicProtection;
            CutProtection = DefaultCutProtection + Armour.DeadMagicProtection;
            StabProtection = DefaultfStabProtection + Armour.StabProtection;
        }
    }

    public void TakeDamage(string KindOfDamage, float damage, GameObject Attacker = null)
    {
        float bonus = 0f;

        if (Attacker != null)
        {
            if (KindOfDamage == "Fire") { bonus += damage * (Attacker.GetComponent<Entity>().FireMagic / 100); }
            if (KindOfDamage == "Water") { bonus += damage * (Attacker.GetComponent<Entity>().WaterMagic / 100); }
            if (KindOfDamage == "DeadMagic") { bonus += damage * (Attacker.GetComponent<Entity>().DeadMagic / 100); }
            if (KindOfDamage == "Cut") { bonus += damage * (Attacker.GetComponent<Entity>().CutDamge / 100); }
            if (KindOfDamage == "Stab") { bonus += damage * (Attacker.GetComponent<Entity>().StabDamge / 100); }

        }

        if (KindOfDamage == "Fire") { bonus += damage * (-FireProtection / 100) / 2; }
        else if (KindOfDamage == "Water") { bonus += damage * (-WaterProtection / 100) / 2; }
        else if(KindOfDamage == "DeadMagic") { bonus += damage * (-DeadMagicProtection / 100) / 2; }
        else if(KindOfDamage == "Cut") { bonus += damage * (-CutProtection / 100) / 2; }
        else if(KindOfDamage == "Stab") { bonus += damage * (-StabProtection / 100) / 2; }




        Debug.Log(bonus);
        Debug.Log(KindOfDamage);
        Debug.Log(FireProtection);

        Health -= damage + bonus;
    }

    private void Die()
    {
        Loot l = Instantiate(loot, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        l.items = DropItems;
        l.player = player;
        Destroy(gameObject);
    }
}
