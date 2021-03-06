namespace BehaviourSystem.Behaviours
{
    public class MoveToTheNearest : NearestEntityDrivenBehaviour
    {
        protected override BehaviourMovement ApplyImpl(Unit properties)
        {
            var nearest = GetNearest(properties);
            var direction = nearest - properties.transform.position;
            return new() {DesiredMovement = direction.normalized};
        }

        public override string GetDescription()
        {
            return $"MoveToTheNearest {entities.GetDescription()}";
        }
    }
}