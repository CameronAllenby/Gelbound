using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class sequence : Node
    {
        public sequence() : base() { }
        public sequence(List<Node> children) : base(children) { }
        public override Nodestate Evaluate()
        {
            bool anyChildIsRunning = false;
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case Nodestate.FAILURE:
                        state = Nodestate.FAILURE;
                        return state;
                    case Nodestate.SUCCESS:
                        continue;
                    case Nodestate.RUNNING:
                        anyChildIsRunning = true;
                        continue;
                    default:
                        state = Nodestate.SUCCESS;
                        return state;
                }
            }

            state = anyChildIsRunning ? Nodestate.RUNNING : Nodestate.SUCCESS;
            return state;
        }
    }
}