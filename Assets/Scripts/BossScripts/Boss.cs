using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using static UnityEngine.Rendering.DebugUI;

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
        public GameObject hitBox;
        public Rigidbody2D srb;
        public Transform bulletPos;
        public int lookDirection;

        public GameObject self;
     
        void Start () 
        {
            bossHealth.SetMaxHealth(maxHealth);
            chasing = new Chase(this, sm);
            attack = new Attack(this, sm);
            inactive = new Inactive(this, sm);
            sm.Init(inactive);
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            srb = GetComponent<Rigidbody2D>();

        }
        void Update ()
        {
            if (health == 0)
            {
                Destroy(self);
            }
            if ( target.transform.position.x > transform.position.x)
            {
                sr.flipX = true;
                lookDirection = 1;
            }
            if (target.transform.position.x < transform.position.x)
            {
                sr.flipX = false;
                lookDirection = -1;
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
                yield return new WaitForSeconds(0.7f);
                HitBox();
                yield return new WaitForSeconds(0.3f);
                anim.Play("idle");
                yield return new WaitForSeconds(1f);
                CheckForChase();
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

        void HitBox()
        {
            GameObject clone;
            clone = Instantiate(hitBox, transform.position, transform.rotation);
            srb = clone.GetComponent<Rigidbody2D>();
            srb.transform.position = new Vector2(transform.position.x + (1 * lookDirection), transform.position.y + 1);
        }
        private void OnTriggerStay2D(Collider2D collision)
        {

            if (collision.CompareTag("PlayerHit") == true)
            {
                TakeDamage(25);
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
        public void CheckForDeath()
        {
            if (health <= 0)
            {
                sm.ChangeState(inactive);
            }
        }

    }
}
