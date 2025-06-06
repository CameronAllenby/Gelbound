using UnityEngine;
using System.Collections;
public class HitBox : MonoBehaviour
{
    private Transform target;
    public SpriteRenderer sr;
    public GameObject hitBox;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine("kill");
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(hitBox);
    }

    private void Update()
    {
        if (target.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
        }
        if (target.transform.position.x < transform.position.x)
        {
            sr.flipX = false;
        }
    }
}
