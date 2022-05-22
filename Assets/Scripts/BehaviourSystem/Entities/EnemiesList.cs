using System.Collections.Generic;
using System.Linq;
using SO;
using UnityEngine;

namespace BehaviourSystem.Entities
{
    public class EnemiesList : IBaseEntitiesList
    {
        public static readonly EnemiesList Instance = new();

        public IEnumerable<Vector3> GetAllEntities(Unit unit)
        {
            return PlayersUnitsListsUtils.GetEnemies(unit)
                .Select(x => x.transform.position);
        }
    }
}