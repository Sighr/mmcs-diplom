
namespace BehaviourSystem.BehaviourPredicates
{
    public class AlliesLess : IBehaviourPredicate
    {
        public float threshold;
    
        public bool ShouldBeApplied(Unit unit)
        {
            return unit.alliedUnits.value.Count < threshold;
        }

        public string GetDescription()
        {
            return $"AlliesLessThan{threshold}";
        }
    }
}