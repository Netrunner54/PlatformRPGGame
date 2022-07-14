using UnityEngine;

public class Ghost : MonoBehaviour
{

    public GameObject player;
    public float speed = 4f;
    public Rigidbody2D rb;

    public SpriteRenderer GhostRenderer;
    public Sprite Right;
    public Sprite Left;



    private string destination = "Right";
    private float x;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= gameObject.transform.position.x - 10 && player.transform.position.x <= gameObject.transform.position.x + 10)
        {
            if (player.transform.position.y >= gameObject.transform.position.y - 5 && player.transform.position.y <= gameObject.transform.position.y + 5)
            {
                int GhostPosX = (int)gameObject.transform.position.x;
                int PlayerPosX = (int)player.transform.position.x;
                if (PlayerPosX > GhostPosX) { x = 0.5f; destination = "Right"; }
                else if (PlayerPosX < GhostPosX) { x = -0.5f; destination = "Left"; }
                //rb.transform.position += new Vector3(x, 0f, 0f) * speed * Time.deltaTime;
                rb.velocity = new Vector3(x, 0f, 0f) * speed;


            }

            if (destination == "Right") { GhostRenderer.sprite = Right; }
            if (destination == "Left") { GhostRenderer.sprite = Left; }
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "player")
        {
            player.GetComponent<Entity>().TakeDamage("DeadMagic", 20, gameObject);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(x * 10, 2f);
        }
    }
}
