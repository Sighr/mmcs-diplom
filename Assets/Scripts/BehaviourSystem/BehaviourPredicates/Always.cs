
namespace BehaviourSystem.BehaviourPredicates
{
    public class Always : IBehaviourPredicate
    {
        public static Always Instance = new();
        public bool ShouldBeApplied(UnitProperties properties)
        {
            return true;
        }
    }
}