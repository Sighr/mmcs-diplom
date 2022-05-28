using UnityEngine;

namespace BehaviourSystem.Behaviours
{
    public class MoveForward : BaseBehaviour
    {
        public static MoveForward Instance = new();
        protected override BehaviourMovement ApplyImpl(Unit properties)
        {
            return new(){DesiredMovement = properties.transform.TransformDirection(Vector3.forward)};
        }

        public override string GetDescription()
        {
            return "MoveForward";
        }
    }
}