using UnityEngine;
namespace Enemies
{
    public class StateMachineEnemy : MonoBehaviour
    {
        public StateEnemy CurrentState { get; private set; }
        public StateEnemy LastState { get; private set; }

        public void Init(StateEnemy startingState)
        {
            CurrentState = startingState;
            LastState = null;
            startingState.Enter();
        }

        public void ChangeState(StateEnemy newState)
        {
            //Debug.Log("Changing state to " + newState);
            CurrentState.Exit();

            LastState = CurrentState;
            CurrentState = newState;
            newState.Enter();


        }

        public StateEnemy GetState()
        {
            return CurrentState;
        }

    }
}
