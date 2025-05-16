using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RangedEnemy : MonoBehaviour
{
    public float speed;

    private Transform target;

    public float stoppingDistance;
    public float stopping;
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
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

    public void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
