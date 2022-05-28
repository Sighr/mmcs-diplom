using UnityEngine;

namespace BehaviourSystem.Behaviours
{
    public class MoveInRadiusWithTheNearest : NearestEntityDrivenBehaviour
    {
        public float radius;
    
        protected override BehaviourMovement ApplyImpl(Unit properties)
        {
            var nearest = GetNearest(properties);
            var position = properties.transform.position;
            var direction = nearest - position;
            return new() {DesiredMovement = Vector3.Lerp(nearest, position, radius/direction.magnitude) - position};
        }

        public override string GetDescription()
        {
            return $"MoveInRadius{radius}WithTheNearest {entities.GetDescription()}";
        }
    }
}