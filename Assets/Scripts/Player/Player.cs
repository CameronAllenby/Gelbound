using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using System.Collections;
using System.Dynamic;

namespace Player
{
    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Rigidbody2D srb;
        public SpriteRenderer sr;
        public Animator anim;
        private bool ground = true;

        //state machine states
        public StateMachine sm;
        public Idle idle;
        public Move move;

        public int health;
        int stamina;
        int maxStamina = 100;
        public int maxHealth = 100;

        public bool cooldown;
        public int lookDirection;

        public GameObject hitBox;
        public GameObject hitBoxSp;

        public healthbar healthbar;
        public Staminabar staminabar;

        public bool flip;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            idle = new Idle(this, sm);
            move = new Move(this, sm);

            sm.Init(idle);

            sr = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
            srb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            StartCoroutine("stamregen");
            cooldown = true;
            stamina = maxStamina;
            health = maxHealth;
            healthbar.SetMaxHealth(maxHealth);
            staminabar.SetMaxStamina(maxStamina);
        }

        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }

        // Update is called once per frame
        void Update()
        {
            if (stamina >= 100)
            {
                stamina = 100;
            }


            if (flip == false)
            {
                lookDirection = 1;
            }
            if(flip == true)
            {
                lookDirection = -1;
            }
            sm.CurrentState.LogicUpdate();

            if (Input.GetAxis("Vertical") != 0 && ground == true)
            {
                anim.Play("jump");
                rb.AddForce(new Vector3(0, 400, 0));
                ground = false;

            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && stamina >= 20)
            {
                rb.AddForce(new Vector2(500 * Input.GetAxis("Horizontal"), 0));
                LoseStamina(20);

                Debug.Log(lookDirection);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject clone;
                clone = Instantiate(hitBox, transform.position, transform.rotation);
                srb = clone.GetComponent<Rigidbody2D>(); 
                srb.transform.position = new Vector2(transform.position.x + (1 * lookDirection), transform.position.y);


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


        public void TakeDamage(int damage)
        {
            health -= damage;

            healthbar.SetHealth(health);
        }

        public void LoseStamina(int damage)
        {
            stamina -= damage;

            staminabar.SetStamina(stamina);
        }

        IEnumerator stamregen()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                LoseStamina(-1);
                yield return null;
            }

        }
    }

}
