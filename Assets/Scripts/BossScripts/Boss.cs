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

        public float sightRange, spottingRange;
        public bool playerInRange, playerAttackRange;

        public Chase chasing;

        public StateMachineEnemy sm;
        public Transform _transform;

        public float speed;

        public Transform target;

        public float stoppingDistance;

        public Animator anim;

        void Start ()
        {
            bossHealth.SetMaxHealth(maxHealth);
            chasing = new Chase(this, sm);
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        }
        void Update ()
        {
            playerAttackRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
            playerInRange = Physics.CheckSphere(transform.position, spottingRange, playerLayer);
            if (playerInRange == true)
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
            if (playerInRange == true)
            {
                
                sm.ChangeState(chasing);
            }
        }
        public void CheckForAttack()
        {
            if (playerAttackRange == true)
            {

            }
        }
        private void OnDrawGizmosSelected()
        {
            //draws the spheres so i can see them in the Unity editor 
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, sightRange);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, spottingRange);
        }
    }
}
