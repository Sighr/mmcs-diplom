using System.Linq;
using SO;

namespace BehaviourSystem.BehaviourPredicates
{
    public class EnemiesLess : IBehaviourPredicate
    {
        public float threshold;
    
        public bool ShouldBeApplied(UnitProperties properties)
        {
            return PlayersUnitsListsUtils.GetEnemies(properties).Count() < threshold;
        }
    }
}