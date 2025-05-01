using UnityEngine;

namespace Enemies
{ 
    public class Boss : MonoBehaviour
    {
        public BossHealth bossHealth;
        public int maxHealth = 2000;
        public int health;
        void Start ()
        {
            bossHealth.SetMaxHealth(maxHealth);
        }
        void Update ()
        {

        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            bossHealth.SetHealth(health);
        }


    }
}
