using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourSystem.Entities
{
    public class PeaksList : IBaseEntitiesList
    {
        public static readonly PeaksList Instance = new();

        public IEnumerable<Vector3> GetAllEntities(Unit unit)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public string GetDescription()
        {
            return "Peak";
        }
    }
}