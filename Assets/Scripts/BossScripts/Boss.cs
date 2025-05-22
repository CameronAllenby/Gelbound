using UnityEngine;
using UnityEngine.UIElements.Experimental;

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

        public Animator anim;

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
            
            if (Vector2.Distance(transform.position, target.position) <= stoppingDistance)
            {
                bossBar.SetActive(true);
            }
            else { bossBar.SetActive(false); }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            bossHealth.SetHealth(health);
        }

        public void CheckForChase()
        {
            //Changes the state if the player is within spoting distance
            if (Vector2.Distance(transform.position, target.position) <= stoppingDistance)
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
            if (Vector2.Distance(transform.position, target.position) <= attackRange)
            {
                sm.ChangeState(inactive);
            }
        }


    }
}
