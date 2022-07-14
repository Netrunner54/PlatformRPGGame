using UnityEngine;

public class fireballMovement : MonoBehaviour
{   
    public string Destination;                                                                              // fireball destination
    public float speed = 12;                                                                                // fireball speed
    public Rigidbody2D rb;                                                                                  // fireball rigidbody 2d
    public Renderer ObjRenderer;                                                                            // fireball renderer
    public ParticleSystem ExplosionParticleSystem;                                                              
    public ParticleSystem TailParticleSystem;
    public GameObject attacker = null;                                                                      // who create spell

    private float TimeToDestroy = 1.05f;
    private float startCountdown = 0;
    private bool destroy = false;

    // Start is called before the first frame update
    void Start()
    {
        ExplosionParticleSystem.Stop();
        if (Destination == "Left")
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z + 180);           // set rotation to 180 deegrees if destination is left
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Destination == "Right")                                             // moving right
        {
            rb.velocity = new Vector3(0.5f, 0f, 0f) * speed;
        }

        else if (Destination == "Left")                                         // moving left
        {
            rb.velocity = new Vector3(-0.5f, 0f, 0f) * speed;
        }

        if (Time.time - startCountdown >= TimeToDestroy && destroy)             // destroy obj when it collides
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "player" || other.collider.tag == "Enemy")                    // Give damege if collides to player or enemy
        {     
            other.collider.GetComponent<Entity>().TakeDamage(gameObject.GetComponent<Spell>().TypeOfDamage, gameObject.GetComponent<Spell>().damage, attacker);
        }

        if (other.collider.tag != "Spell")                                                      // destroy particles and effects
        {
            ObjRenderer.enabled = false;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            TailParticleSystem.Stop();
            destroy = true;
            startCountdown = Time.time;
            Destination = "NULL";
            ExplosionParticleSystem.Play();
        }
        Debug.Log("Dollision With Player");
    }
}
