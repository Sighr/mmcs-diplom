using System.Collections.Generic;
using BehaviourSystem.Entities;
using UnityEngine;

namespace BehaviourSystem.Behaviours
{
    public abstract class NearestEntityDrivenBehaviour : BaseBehaviour
    {
        public IBaseEntitiesList Entities;

        protected Vector3 GetNearest(UnitProperties properties)
        {
            return EntitiesUtils.GetNearest(properties, Entities.GetAllEntities(properties));
        }
    }
}