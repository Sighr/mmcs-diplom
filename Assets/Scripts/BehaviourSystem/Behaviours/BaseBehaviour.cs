using BehaviourSystem.BehaviourPredicates;

namespace BehaviourSystem.Behaviours
{
    public abstract class BaseBehaviour
    {
        public IBehaviourPredicate Predicate;
    
        public BehaviourMovement Apply(Unit properties)
        {
            if (!Predicate.ShouldBeApplied(properties))
                return BehaviourMovement.Stay;
            return ApplyImpl(properties);
        }

        protected abstract BehaviourMovement ApplyImpl(Unit properties);
        public abstract string GetDescription();
    }
}