using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections;
using UnityEngine.AI;
using Player;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Follow", story: "[Self] the [player]", category: "Action", id: "aba4de0b3d7bf814d4bfb7041a50e6cd")]
public partial class FollowAction : Action
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(
        name: "Navigate To Location",
        description: "Navigates a GameObject to a specified position using NavMeshAgent." +
        "\nIf NavMeshAgent is not available on the [Agent] or its children, moves the Agent using its transform.",
        story: "[Agent] navigates to [Location]",
        category: "Action/Navigation",
        id: "c67c5c55de9fe94897cf61976250cc83")]
    
    internal partial class NavigateToLocationAction : Action
    {

        [SerializeReference] public BlackboardVariable<SpriteRenderer> sr;
        [SerializeReference] public BlackboardVariable<Transform> Target;
        [SerializeReference] public BlackboardVariable<Transform> Transform;
        [Tooltip("True: the node process the LookAt every update with status Running." +
            "\nFalse: the node process the LookAt only once.")]
        [SerializeReference] public BlackboardVariable<bool> Continuous = new BlackboardVariable<bool>(false);
        [SerializeReference] public BlackboardVariable<bool> LimitToYAxis = new BlackboardVariable<bool>(false);

        protected override Status OnStart()
        {
            if (Transform.Value == null || Target.Value == null)
            {
                LogFailure($"Missing Transform or Target.");
                return Status.Failure;
            }

            ProcessLookAt();
            return Continuous.Value ? Status.Running : Status.Success;
        }

        protected override Status OnUpdate()
        {
            if (Continuous.Value)
            {
                ProcessLookAt();
                return Status.Running;
            }
            return Status.Success;
        }

        void ProcessLookAt()
        {
           
                

            
        }
    }
}

