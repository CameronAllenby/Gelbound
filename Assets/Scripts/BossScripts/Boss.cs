using UnityEngine;
using System.Collections;
using UnityEngine.UIElements.Experimental;
using Unity.VisualScripting;

namespace Enemies
{ 
    public class Boss : MonoBehaviour
    {
        public BossHealth bossHealth;
        public int maxHealth = 2000;
        public int health;

        public GameObject bossBar;
        public LayerMask playerLayer;

        public Chase chasing;
        public Attack attack;
        public Inactive inactive;

        public StateMachineEnemy sm;
        public Transform _transform;

        public float speed;

        public Transform target;

        public float stoppingDistance;
        public float attackRange;
        public float looseSight;
        public SpriteRenderer sr;
        public Animator anim;

        public GameObject bullet;
        public Transform bulletPos;
     
        void Start () 
        {
            bossHealth.SetMaxHealth(maxHealth);
            chasing = new Chase(this, sm);
            attack = new Attack(this, sm);
            inactive = new Inactive(this, sm);
            sm.Init(inactive);
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            

        }
        void Update ()
        {
            if ( target.transform.position.x > transform.position.x)
            {
                sr.flipX = true;
            }
            if (target.transform.position.x < transform.position.x)
            {
                sr.flipX = false;
            }
                Debug.Log("boss" + sm.CurrentState);
            sm.CurrentState.LogicUpdate();
            if (Vector2.Distance(transform.position, target.position) <= stoppingDistance)
            {
                bossBar.SetActive(true);
            }
            else { bossBar.SetActive(false); }
        }
        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }
        public void TakeDamage(int damage)
        {
            health -= damage;

            bossHealth.SetHealth(health);
        }
        IEnumerator Attacking()
        {
            while (true)
            {
                anim.Play("1_atk");
                yield return new WaitForSeconds(1f);
                anim.Play("idle");
                yield return new WaitForSeconds(1f);
                yield return null;
            }
        }

        IEnumerator shooting()
        {
            while (true)
            {
                yield return new WaitForSeconds(3f);
                shoot();
                yield return null;
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {

            if (collision.CompareTag("PlayerHit") == true)
            {
                TakeDamage(10);
            }
        }

        public void shoot()
        {
            int shots = 0;
            while (shots <= 5)
            {
                Instantiate(bullet, bulletPos.position, Quaternion.identity);
                shots++;
            }
        }


        public void CheckForChase()
        {
            //Changes the state if the player is within spoting distance
            if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > attackRange)
            {
                sm.ChangeState(chasing);
            }
        }
        public void CheckForAttack()
        {
            if (Vector2.Distance(transform.position, target.position) <= attackRange)
            {
                sm.ChangeState(attack);
            }
        }

        public void CheckForInactive()
        {
            if (Vector2.Distance(transform.position, target.position) >= looseSight)
            {
                sm.ChangeState(inactive);
            }
        }


    }
}
