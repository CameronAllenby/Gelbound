using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Selector : Node
    {
        public Selector() : base() { }
        public Selector(List<Node> children) : base(children) { }
        public override Nodestate Evaluate()
        {
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case Nodestate.FAILURE:
                        continue;
                    case Nodestate.SUCCESS:
                        state = Nodestate.SUCCESS;
                        return state;
                    case Nodestate.RUNNING:
                        state = Nodestate.RUNNING;
                        return state;
                    default:
                        continue;
                }
            }

            state = Nodestate.FAILURE;
            return state;
        }
    }
}