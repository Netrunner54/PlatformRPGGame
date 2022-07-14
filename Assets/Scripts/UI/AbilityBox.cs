using UnityEngine;
using UnityEngine.UI;

public class AbilityBox : MonoBehaviour
{
    private  GameObject player;
    public AbilityBoxes abilityBoxes;
    public GameObject Spell = null;
    public Image SpellImg;
    public TMPro.TextMeshProUGUI SpellName;
    public int BoxNumber;

    public string Spell_Name = null;
    

    private void Start()
    {
        player = abilityBoxes.player;
        if (Spell != null)
        {
            SpellImg.sprite = Spell.GetComponent<SpriteRenderer>().sprite;
            SpellImg.color = new Color(255, 255, 255, 255);
            SpellName.text = Spell.name;
            Spell_Name = Spell.name;
        }

}

    private void Update()
    {
        if (BoxNumber == 1) { Spell = abilityBoxes.Box_1; }
        if (BoxNumber == 2) { Spell = abilityBoxes.Box_2; }
        if (BoxNumber == 3) { Spell = abilityBoxes.Box_3; }
        if (BoxNumber == 4) { Spell = abilityBoxes.Box_4; }


        if (Spell != null)
        {
            SpellImg.sprite = Spell.GetComponent<SpriteRenderer>().sprite;
            SpellImg.color = new Color(255, 255, 255, 255);
            SpellName.text = Spell.name;
            Spell_Name = Spell.name;


            if (player.GetComponent<Entity>().Mana < Spell.GetComponent<Spell>().costOfSpell)
            {
                SpellImg.color = new Color(150, 150, 150, 255);

            }
            else { SpellImg.color = new Color(255, 255, 255, 255); }
        }
        else { SpellImg.color = new Color(0, 0, 0, 0); SpellName.text = "Empty"; Spell_Name = null; }


    }
}
