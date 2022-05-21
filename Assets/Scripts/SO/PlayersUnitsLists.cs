using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "PlayersUnits", menuName = "RuntimeSO/PlayersUnitsLists")]
    public class PlayersUnitsLists : ScriptableObject
    {
        [System.Serializable]
        public class DictEntry
        {
            public PlayerTag playerTag;
            public UnitsList units;
        }
    
        public List<DictEntry> initializerList;
        public Dictionary<PlayerTag, UnitsList> value;
        public void OnEnable()
        {
            value = new();
            foreach (var entry in initializerList)
            {
                value[entry.playerTag] = entry.units;
            }
        }
    }

    public static class PlayersUnitsListsUtils
    {
        public static IEnumerable<UnitProperties> GetEnemies(UnitProperties properties)
        {
            return properties.playersUnits.value
                .Where(kvp => kvp.Key != properties.owner)
                .SelectMany(kvp => kvp.Value.value);
        }
    }
}