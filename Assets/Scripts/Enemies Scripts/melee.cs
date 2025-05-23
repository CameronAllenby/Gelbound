using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.DebugUI;

public class Melee : MonoBehaviour
{
    public float speed;
    public SpriteRenderer sr;
    private Transform target;

    public float stoppingDistance;
    public float stopping;

    private int health = 100;
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
        if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > stopping)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, target.position) < stopping)
        {


        }
    }
}
