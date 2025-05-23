using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RangedEnemy : MonoBehaviour
{
    public float speed;

    private Transform target;
    public SpriteRenderer sr;
    public float stoppingDistance;
    public float stopping;
    public GameObject bullet;
    public Transform bulletPos;
    public int health = 2;
    private float timer;
    public GameObject self;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {

        if (target.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
        }
        if (target.transform.position.x < transform.position.x)
        {
            sr.flipX = false;
        }

        if (health == 0)
        {
            Destroy(self);
        }
        timer += Time.deltaTime;

        if (Vector2.Distance(transform.position, target.position) < stoppingDistance)
        {
            if (Vector2.Distance(transform.position, target.position) > stopping)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit") == true)
        {
            health--;
        }


    }
    public void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }


}
