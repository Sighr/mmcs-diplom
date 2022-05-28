using BehaviourSystem.Entities;
using UnityEngine;

namespace BehaviourSystem.Behaviours
{
    public abstract class NearestEntityDrivenBehaviour : BaseBehaviour
    {
        public IBaseEntitiesList entities;
        public abstract override string GetDescription();

        protected Vector3 GetNearest(Unit properties)
        {
            return EntitiesUtils.GetNearest(properties, entities.GetAllEntities(properties));
        }
    }
}