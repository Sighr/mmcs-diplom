namespace BehaviourSystem.Behaviours
{
    public class MoveAwayFromTheNearest : NearestEntityDrivenBehaviour
    {
        protected override BehaviourMovement ApplyImpl(Unit properties)
        {
            var nearest = GetNearest(properties);
            var direction = nearest - properties.transform.position;
            return new() {DesiredMovement = -direction.normalized};
        }

        public override string GetDescription()
        {
            return $"MoveAwayFromTheNearest {entities.GetDescription()}";
        }
    }
}