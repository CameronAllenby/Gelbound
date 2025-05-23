using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public GameObject self;
    public float force;
    public Animator anim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2 (direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("Ground") || collision.CompareTag("Player")) == true)
        {
            Destroy(self);
        }
    }

    
}
