
namespace BehaviourSystem.BehaviourPredicates
{
    public class HpLow : IBehaviourPredicate
    {
        public float threshold;
    
        public bool ShouldBeApplied(UnitProperties properties)
        {
            return properties.hp < threshold;
        }
    }
}