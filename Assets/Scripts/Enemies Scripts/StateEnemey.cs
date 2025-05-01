using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Enemies
{
    public abstract class StateEnemy
    {
        public Boss boss;
        protected StateMachineEnemy sm;



        // base constructor
        protected StateEnemy(Boss boss, StateMachineEnemy sm)
        {
            this.boss = boss;
            this.sm = sm;
        }

        // These methods are common to all states
        public virtual void Enter()
        {
            //Debug.Log("This is base.enter");
        }

        public virtual void HandleInput()
        {
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Exit()
        {
        }

    }

}
