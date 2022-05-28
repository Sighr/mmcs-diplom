using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourSystem.Entities
{
    public class AlliesList : IBaseEntitiesList
    {
        public static readonly AlliesList Instance = new();

        public IEnumerable<Vector3> GetAllEntities(Unit unit)
        {
            return unit.alliedUnits.value
                .Where(x => x != unit)
                .Select(x => x.transform.position);
        }

        public string GetDescription()
        {
            return "Allies";
        }
    }
}