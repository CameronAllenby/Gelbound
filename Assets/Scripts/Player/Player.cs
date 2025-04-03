using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using System.Collections;

namespace Player
{
    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;
        public SpriteRenderer sr;
        public Animator anim;
        private bool ground = true;

        //state machine states
        public StateMachine sm;
        public Idle idle;
        public Move move;

        public int health;
        int stamina;
        int maxStamina;
        public int maxHealth = 100;

        public bool cooldown;
        public int dashDirection;

        public GameObject hitBox;

        public healthbar healthbar;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            idle = new Idle(this, sm);
            move = new Move(this, sm);

            sm.Init(idle);

            sr = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            string s;

            cooldown = true;

            health = maxHealth;
            healthbar.SetMaxHealth(maxHealth);
        }

        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }

        // Update is called once per frame
        void Update()
        {
            sm.CurrentState.LogicUpdate();

            
            if (Input.GetKey(KeyCode.W) && ground == true)
            {
                anim.Play("jump");
                rb.AddForce(new Vector3(0, 400, 0));
                ground = false;
            }

            if (Input.GetKey(KeyCode.Q) && cooldown == true)
            {


                if (sr.flipX == true)
                {
                    dashDirection = -1;
                    rb.AddForce(new Vector3(-10, 0, 0));
                    StartCoroutine("Dash");
                }
                if (sr.flipX == false)
                {

                    dashDirection = 1;
                    rb.AddForce(new Vector3(-10, 0, 0));
                    StartCoroutine("Dash");

                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject clone;
                clone = Instantiate(hitBox, transform.position, transform.rotation);

                
            }
        }

        //Idle check
        public void CheckForIdle()
        {
            if (rb.linearVelocityX == 0)
            {
                sm.ChangeState(idle);
            }
        }

        public void CheckForInAir()
        {

        }

        public void CheckForMovment()
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                sm.ChangeState(move);
            }
        }

        public void Attack()
        {
            GameObject clone;
            clone = Instantiate(hitBox, transform.position, transform.rotation);

            rb.transform.position = new Vector2(transform.position.x +(2*dashDirection), transform.position.y + 1);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground") == true)
            {
                Debug.Log("ground");
                ground = true;
            }

            if (collision.CompareTag("Projectile") == true)
            {
                TakeDamage(10);
            }
        }

        IEnumerator Dash()
        {
            cooldown = false;
            yield return new WaitForSecondsRealtime(2);
            cooldown = true;
        }

        void TakeDamage(int damage)
        {
            health -= damage;

            healthbar.SetHealth(health);
        }
    }

}
