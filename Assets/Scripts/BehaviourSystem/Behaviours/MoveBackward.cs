using UnityEngine;

namespace BehaviourSystem.Behaviours
{
    public class MoveBackward : BaseBehaviour
    {
        public static MoveBackward Instance = new();
        protected override BehaviourMovement ApplyImpl(Unit properties)
        {
            return new(){DesiredMovement = properties.transform.TransformDirection(Vector3.back)};
        }

        public override string GetDescription()
        {
            return "MoveBackward";
        }
    }
}