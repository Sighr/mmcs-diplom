using SO;
using UnityEngine;

namespace HealthSystem
{
    public class HealthSystem : MonoBehaviour
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

            for (var i = allUnits.value.Count - 1; i >= 0; i--)
            {
                var unit = allUnits.value[i];
                if (unit.hp > 0)
                {
                    continue;
                }

                Destroy(unit.gameObject);
            }
        }
    }
}