
namespace BehaviourSystem.BehaviourPredicates
{
    public class HpLow : IBehaviourPredicate
    {
        public float threshold;
    
        public bool ShouldBeApplied(Unit unit)
        {
            return unit.hp < threshold;
        }

        public string GetDescription()
        {
            return $"HpLessThan{threshold}";
        }
    }
}