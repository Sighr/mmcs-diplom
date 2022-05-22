
namespace BehaviourSystem.BehaviourPredicates
{
    public class Always : IBehaviourPredicate
    {
        public static Always Instance = new();
        public bool ShouldBeApplied(Unit unit)
        {
            return true;
        }
    }
}