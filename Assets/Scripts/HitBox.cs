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
        yield return new WaitForSeconds(0.05f);
        Destroy(hitBox);
    }
    
}
