using SO;
using UnityEngine;

namespace AbilitySystem
{
    public class AbilitySystem : MonoBehaviour
    {
        public UnitsList allUnits;
        private bool _simulating;

        public void OnSimulationStart()
        {
            _simulating = true;
        }
    
        public void OnSimulationEnd()
        {
            _simulating = false;
        }
    
        private void FixedUpdate()
        {
            if (!_simulating)
            {
                return;
            }
            foreach (var unit in allUnits.value)
            {
                foreach (var ability in unit.abilities)
                {
                    ability.Apply(unit);
                }
            }
        }
    }
}