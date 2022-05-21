﻿namespace BehaviourSystem.Behaviours
{
    public class MoveToTheNearest : NearestEntityDrivenBehaviour
    {
        protected override BehaviourMovement ApplyImpl(UnitProperties properties)
        {
            var nearest = GetNearest(properties);
            var direction = nearest - properties.transform.position;
            return new() {DesiredMovement = direction.normalized};
        }    
    }
}