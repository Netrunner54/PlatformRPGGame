using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    public GameObject player;
    public GameObject healthBar;
    public TMPro.TextMeshProUGUI playerHealthValue;
    public GameObject manaBar;
    public TMPro.TextMeshProUGUI playerManaValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var HP = player.GetComponent<Entity>().Health / player.GetComponent<Entity>().maxHealth;
        healthBar.GetComponent<Slider>().value = HP;
        int intHP = (int)player.GetComponent<Entity>().Health;
        playerHealthValue.text = intHP.ToString();

        var Mana = player.GetComponent<Entity>().Mana / player.GetComponent<Entity>().maxMana;
        manaBar.GetComponent<Slider>().value = Mana;
        int intMana = (int)player.GetComponent<Entity>().Mana;
        playerManaValue.text = intMana.ToString();
    }
}
