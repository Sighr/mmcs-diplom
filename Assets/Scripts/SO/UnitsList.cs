using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "Units", menuName = "RuntimeSO/UnitsList")]
    public class UnitsList : ScriptableObject
    {
        public List<Unit> value;

        private void OnEnable()
        {
            value = new List<Unit>();
        }

        public void Register(Unit unit)
        {
            if (value.Contains(unit))
            {
                return;
            }
            value.Add(unit);
        }
    
        public void Unregister(Unit unit)
        {
            value.Remove(unit);
        }
    }
}