using System.Collections.Generic;
using UnityEngine;

namespace BehaviourSystem.Entities
{
    public interface IBaseEntitiesList
    {
        public IEnumerable<Vector3> GetAllEntities(Unit unit);
    }
    
    public static class EntitiesUtils
    {
        public static Vector3 GetNearest(Unit properties, IEnumerable<Vector3> positions)
        {
            float minDistance = float.MaxValue;
            Vector3 nearest = Vector3.zero;
            foreach (var position in positions)
            {
                var distance = (properties.transform.position - position).sqrMagnitude;
                if (distance < minDistance)
                {
                    nearest = position;
                    minDistance = distance;
                }
            }
            return nearest;
        }
    }
}