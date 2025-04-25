using System.Collections;
using UnityEngine;


namespace Enemy
{
    public abstract class Oak : MonoBehaviour
    {
        private Node _root = null;

        protected void Start()
        {
            _root = SetupTree();
        }

        protected void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }
        protected abstract Node SetupTree();
    }
}

