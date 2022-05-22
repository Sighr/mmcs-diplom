using BehaviourSystem.Entities;
using UnityEngine;

namespace BehaviourSystem.Behaviours
{
    public abstract class NearestEntityDrivenBehaviour : BaseBehaviour
    {
        public IBaseEntitiesList Entities;

        protected Vector3 GetNearest(Unit properties)
        {
            return EntitiesUtils.GetNearest(properties, Entities.GetAllEntities(properties));
        }
    }
}