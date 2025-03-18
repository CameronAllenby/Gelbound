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

        int health;
        int stamina;

        public bool cooldown;
        public int dashDirection;
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
            s = string.Format("last state={0}\ncurrent state={1}", sm.LastState, sm.CurrentState);
            Console.WriteLine(s);
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
                    dashDirection = -90;
                    rb.AddForce(new Vector3(dashDirection, 0, 0));
                    StartCoroutine("Dash");
                }
                if (sr.flipX == false)
                {

                    dashDirection = 90;
                    rb.AddForce(new Vector3(dashDirection, 0, 0));
                    StartCoroutine("Dash");

                }



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
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) && ground == true)
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
        }

        IEnumerator Dash()
        {
            cooldown = false;
            rb.AddForce(new Vector3(dashDirection, 0, 0));
            yield return new WaitForSecondsRealtime(2);
            cooldown = true;

        }

    }

}
