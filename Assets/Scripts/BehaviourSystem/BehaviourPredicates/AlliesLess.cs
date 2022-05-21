
namespace BehaviourSystem.BehaviourPredicates
{
    public class AlliesLess : IBehaviourPredicate
    {
        public float threshold;
    
        public bool ShouldBeApplied(UnitProperties properties)
        {
            return properties.alliedUnits.value.Count < threshold;
        }
    }
}