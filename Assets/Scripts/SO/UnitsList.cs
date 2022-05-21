using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "Units", menuName = "RuntimeSO/UnitsList")]
    public class UnitsList : ScriptableObject
    {
        public List<UnitProperties> value;

        private void OnEnable()
        {
            value = new List<UnitProperties>();
        }

        public void Register(UnitProperties properties)
        {
            if (value.Contains(properties))
            {
                return;
            }
            value.Add(properties);
        }
    
        public void Unregister(UnitProperties properties)
        {
            value.Remove(properties);
        }
    }
}