using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Melee : MonoBehaviour
{
    public float speed;

    private Transform target;

    public float stoppingDistance;
    public float stopping;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > stopping)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, target.position) < stopping)
        {

        }
    }
}
