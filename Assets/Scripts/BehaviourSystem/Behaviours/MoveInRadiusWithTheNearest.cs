using UnityEngine;

namespace BehaviourSystem.Behaviours
{
    public class MoveInRadiusWithTheNearest : NearestEntityDrivenBehaviour
    {
        public float Radius;
    
        protected override BehaviourMovement ApplyImpl(UnitProperties properties)
        {
            var nearest = GetNearest(properties);
            var position = properties.transform.position;
            var direction = nearest - position;
            return new() {DesiredMovement = Vector3.Lerp(nearest, position, Radius/direction.magnitude) - position};
        }    
    }
}