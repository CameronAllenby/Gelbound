using Unity.VisualScripting;
using UnityEngine;
namespace Player
{
    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;
        public SpriteRenderer sr;
        public Animator anim;
        private bool ground = true;

        int health;
        int stamina;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (rb.linearVelocityX >= 3)
            {
                rb.linearVelocityX = 3;
            }
            if (rb.linearVelocityX <= -3)
            {
                rb.linearVelocityX = -3;
            }
            if (Input.GetKey(KeyCode.D))
            {
                anim.Play("run");
                rb.AddForce(new Vector3(3,0,0));
                sr.flipX = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                anim.Play("run");
                rb.AddForce(new Vector3(-3, 0, 0));
                sr.flipX = true;
            }
            if (Input.GetKey(KeyCode.W) && ground == true)
            {
                anim.Play("jump");
                rb.AddForce(new Vector3(0, 400, 0));
                ground = false;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground") == true)
            {
                Debug.Log("ground");
                ground = true;
            }
        }

    }

}
