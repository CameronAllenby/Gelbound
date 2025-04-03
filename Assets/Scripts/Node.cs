using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

namespace Enemy
{
    public enum Nodestate
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }
    public class Node 
    {
        protected Nodestate state;

        public Node parent;
        protected List<Node> children = new List<Node>();

        public Node()
        {
            parent = null;
        }
        public Node(List<Node> children)
        {
            foreach (Node child in children)
            {
                
            }
        }

        private void _Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual Nodestate Evaluate() => Nodestate.FAILURE;
    }
}

