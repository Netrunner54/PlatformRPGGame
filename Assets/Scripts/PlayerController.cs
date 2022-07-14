using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 4;
    public float jumpHeight = 10;
    public int jumps = 0;
    public SpriteRenderer spriteRenderer;
    public Sprite DefaultSprite;
    public Sprite right;
    public Sprite left;
    public GameObject GroundCheck;
    public GameObject FireballPrefab;
    public GameObject IceballPrefab;
    public string SelectedSpell = null;
    public GameObject HUD;
    public Canvas PlayerInventory;
    private Canvas OpenInventory;
    public Canvas PlayerAlchemy;
    private Canvas OpenAlchemy;


    public Image Ability_1;
    public Image Ability_2;
    public Image Ability_3;
    public Image Ability_4;


    private bool isInventoryOpen = false;
    private bool isAlchemyOpen = false;
    public string lookingSide;
    private float fireball_x;
    private string FireballDestination;
    private bool isGrounded;
    public LayerMask WhatIsGround;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(1f / Time.deltaTime);
        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);                       // jump
            jumps -= 1;
        }

        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown("f"))
        {
            // create fireball
            if (SelectedSpell == "Fireball")
            {
                if (lookingSide == "Right") { fireball_x = gameObject.transform.position.x + 0.5f; }
                else if (lookingSide == "Left") { fireball_x = gameObject.transform.position.x - 0.9f; }
                else { fireball_x = 0; FireballDestination = "Right"; }
                GameObject Fireball = Instantiate(FireballPrefab, new Vector3(fireball_x, transform.position.y, transform.position.z), Quaternion.identity);
                if (gameObject.GetComponent<Entity>().Mana > Fireball.GetComponent<Spell>().costOfSpell)
                {
                    Fireball.GetComponent<fireballMovement>().Destination = lookingSide;
                    gameObject.GetComponent<Entity>().Mana -= Fireball.GetComponent <Spell >().costOfSpell;
                    Fireball.GetComponent<fireballMovement>().attacker = gameObject;
                }
                else { Destroy(Fireball); }
            }

            // create iceball
            else if (SelectedSpell == "IceBall")
            {
                if (lookingSide == "Right") { fireball_x = gameObject.transform.position.x + 0.9f; }
                else if (lookingSide == "Left") { fireball_x = gameObject.transform.position.x - 0.9f; }
                else { fireball_x = 0; }
                GameObject Iceball = Instantiate(IceballPrefab, new Vector3(fireball_x, transform.position.y, transform.position.z), Quaternion.identity);
                if (gameObject.GetComponent<Entity>().Mana > Iceball.GetComponent<Spell>().costOfSpell)
                {
                    Iceball.GetComponent<fireballMovement>().Destination = lookingSide;
                    gameObject.GetComponent<Entity>().Mana -= Iceball.GetComponent<Spell>().costOfSpell;
                }
                else { Destroy(Iceball); }
            }
        }

        if (Input.GetKeyDown("1"))
        {
            SelectedSpell = Ability_1.GetComponent<AbilityBox>().Spell_Name;
        }
        if (Input.GetKeyDown("2"))
        {
            SelectedSpell = Ability_2.GetComponent<AbilityBox>().Spell_Name;
        }
        if (Input.GetKeyDown("3"))
        {
            SelectedSpell = Ability_3.GetComponent<AbilityBox>().Spell_Name;
        }
        if (Input.GetKeyDown("4"))
        {
            SelectedSpell = Ability_4.GetComponent<AbilityBox>().Spell_Name;
        }


        if (Input.GetKeyDown("i"))
        {
            if (!isInventoryOpen)
            {
               if (isAlchemyOpen) { Destroy(OpenAlchemy.gameObject); isAlchemyOpen = false; }

                OpenInventory = Instantiate(PlayerInventory);
                OpenInventory.GetComponent<InventorySystem>().inventory = gameObject.GetComponent<InventoryItems>();
                OpenInventory.GetComponent<InventorySystem>().player = gameObject;
                OpenInventory.GetComponent<InventorySystem>().playerArmorSystem = gameObject.GetComponent<PlayerArmorSystem>();
                isInventoryOpen = true;
                Time.timeScale = 0;

            }
            else if (isInventoryOpen) { Destroy(OpenInventory.gameObject); isInventoryOpen = false; Time.timeScale = 1; }
        }


        if (Input.GetKeyDown("l"))
        {
            if (!isAlchemyOpen)
            {
                if (isInventoryOpen) { Destroy(OpenInventory.gameObject); isInventoryOpen = false; }

                OpenAlchemy = Instantiate(PlayerAlchemy);
                OpenAlchemy.GetComponent<AlchemySystem>().Ingreedients = gameObject.GetComponent<AlchemicalIngreedients>();
                OpenAlchemy.GetComponent<AlchemySystem>().player = gameObject;
                isAlchemyOpen = true;
                Time.timeScale = 0;

            }
            else if (isAlchemyOpen) { Destroy(OpenAlchemy.gameObject); isAlchemyOpen = false; Time.timeScale = 1; }
        }
        
            
    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(GroundCheck.transform.position, 0.2f, WhatIsGround);

        if (isGrounded)
        {
            jumps = 1;
        }


        // moving right/left
        var movement = Input.GetAxis("Horizontal");
        Vector3 Move = rb.velocity;
        Move.x = movement * speed;
        Move.z = 0f;
        rb.velocity = Move;

        if (movement > 0)
        {
            spriteRenderer.sprite = right;
            lookingSide = "Right";
        }


        else if (movement < 0)
        {
            spriteRenderer.sprite = left;
            lookingSide = "Left";
        }

        
        //if (Input.GetKeyDown(KeyCode.LeftShift)) 
        //{ 
            //if (lookingSide == "Right")
            //{
            //    rb.MovePosition(new Vector2(gameObject.transform.position.x + 1f, gameObject.transform.position.y));
            //}
            //if (lookingSide == "Left")
            //{
            //    rb.MovePosition(new Vector2(gameObject.transform.position.x - 1f, gameObject.transform.position.y));
            //}

        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
    }
}
