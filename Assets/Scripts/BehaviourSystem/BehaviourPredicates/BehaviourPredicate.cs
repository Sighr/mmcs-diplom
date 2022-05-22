namespace BehaviourSystem.BehaviourPredicates
{
    public interface IBehaviourPredicate
    {
        public bool ShouldBeApplied(Unit unit);
    }
}