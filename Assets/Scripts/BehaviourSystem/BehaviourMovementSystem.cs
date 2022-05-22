using System.Collections.Generic;
using SO;
using UnityEngine;

namespace BehaviourSystem
{
    public class BehaviourMovementSystem : MonoBehaviour
    {
        public UnitsList allUnits;
        private readonly Dictionary<Unit, BehaviourMovement[]> movements = new();
        private Dictionary<Unit, Rigidbody> unitRbs = new();
        private bool _simulating;

        public void OnSimulationStart()
        {
            _simulating = true;
            foreach (var unit in allUnits.value)
            {
                movements.Add(unit, new BehaviourMovement[unit.behaviours.Count]);
                unitRbs.Add(unit, unit.GetComponent<Rigidbody>());
            }
        }
    
        public void OnSimulationEnd()
        {
            _simulating = false;
            movements.Clear();
            unitRbs.Clear();
        }
    
        private void FixedUpdate()
        {
            if (!_simulating)
            {
                return;
            }
            foreach (var unit in allUnits.value)
            {
                for (var index = 0; index < unit.behaviours.Count; index++)
                {
                    var behaviour = unit.behaviours[index];
                    movements[unit][index] = behaviour.Apply(unit);
                }
                ApplyMovement(unit);
            }
        }

        private void ApplyMovement(Unit unit)
        {
            var direction = Vector3.zero;
            foreach (var movement in movements[unit])
            {
                direction += movement.DesiredMovement;
            }
            if (direction != Vector3.zero)
            {
                direction.Normalize();
                var force = direction * (unit.speed * Time.fixedDeltaTime);
                Debug.DrawRay(unit.transform.position, force * 100, Color.green);
                unitRbs[unit].AddForce(force);
                unit.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            }
        }
    }
}