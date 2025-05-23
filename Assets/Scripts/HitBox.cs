using UnityEngine;
using System.Collections;
public class HitBox : MonoBehaviour
{
    public GameObject hitBox;
    void Start()
    {
        StartCoroutine("kill");
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(hitBox);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") == true)
        {
            Destroy(hitBox);
        }
    }
}
