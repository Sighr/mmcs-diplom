using UnityEngine;

namespace BehaviourSystem.Behaviours
{
    public class MoveForward : BaseBehaviour
    {
        protected override BehaviourMovement ApplyImpl(UnitProperties properties)
        {
            return new(){DesiredMovement = properties.transform.TransformDirection(Vector3.forward)};
        }
    }
}