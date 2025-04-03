using UnityEngine;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    public void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
