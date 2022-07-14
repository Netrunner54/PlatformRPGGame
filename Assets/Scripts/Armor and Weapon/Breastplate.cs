using UnityEngine;

public class Breastplate : MonoBehaviour
{
    public string direction;
    public Sprite Right;

    private SpriteRenderer Renderer;

    public float FireProtection = 0;
    public float WaterProtection = 0;
    public float DeadMagicProtection = 0;
    public float StabProtection = 0;
    public float CutProtection = 0;

    public GameObject Enchant = null;

    public bool couldBeTakeOff = true;

    // Start is called before the first frame update
    void Start()
    {
        Renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == "Right") { Renderer.sprite = Right; Renderer.flipX = false; }
        else if (direction == "Left") { Renderer.sprite = Right; Renderer.flipX = true; }


    }
}
