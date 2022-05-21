using System.Collections.Generic;
using System.Linq;
using SO;
using UnityEngine;

namespace BehaviourSystem.Entities
{
    public class EnemiesList : IBaseEntitiesList
    {
        public IEnumerable<Vector3> GetAllEntities(UnitProperties properties)
        {
            return PlayersUnitsListsUtils.GetEnemies(properties)
                .Select(x => x.transform.position);
        }
    }
}