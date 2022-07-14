using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Sprite weaponSprite;
    public string Name;
    public float damage;

    public string direction = "Right";
    public Vector3 Position;

    public GameObject Enchant;


    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {

      
    }

    float GetDamage()
    {
        float damageWithBonus = damage;
        return damageWithBonus;
    }
}
