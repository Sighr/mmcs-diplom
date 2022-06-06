using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourSystem.Entities
{
    public class RocksList : IBaseEntitiesList
    {
        public static readonly RocksList Instance = new();
        private GameObject[] _rocks;
        
        public IEnumerable<Vector3> GetAllEntities(Unit unit)
        {
            _rocks ??= GameObject.FindGameObjectsWithTag("Rock");
            return _rocks.Select((r) => r.transform.position);
        }

        public string GetDescription()
        {
            return "Rock";
        }
    }
}