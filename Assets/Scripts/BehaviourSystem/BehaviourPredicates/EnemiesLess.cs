using System.Linq;
using SO;

namespace BehaviourSystem.BehaviourPredicates
{
    public class EnemiesLess : IBehaviourPredicate
    {
        public float threshold;
    
        public bool ShouldBeApplied(Unit unit)
        {
            return PlayersUnitsListsUtils.GetEnemies(unit).Count() < threshold;
        }
    }
}