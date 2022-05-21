using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourSystem.Entities
{
    public class AlliesList : IBaseEntitiesList
    {
        public IEnumerable<Vector3> GetAllEntities(UnitProperties properties)
        {
            return properties.alliedUnits.value
                .Where(x => x != properties)
                .Select(x => x.transform.position);
        }
    }
}