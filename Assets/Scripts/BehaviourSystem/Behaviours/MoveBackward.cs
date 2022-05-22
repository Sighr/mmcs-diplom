using UnityEngine;

namespace BehaviourSystem.Behaviours
{
    public class MoveBackward : BaseBehaviour
    {
        protected override BehaviourMovement ApplyImpl(Unit properties)
        {
            return new(){DesiredMovement = properties.transform.TransformDirection(Vector3.back)};
        }
    }
}