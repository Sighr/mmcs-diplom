using SO;
using UnityEngine;

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
        foreach (var unit in allUnits.value)
        {
            if (unit.hp > 0)
            {
                continue;
            }
            Destroy(unit.gameObject);
        }
    }
}