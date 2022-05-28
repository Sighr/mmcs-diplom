using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "Variables/Int", order = 0)]
    public class IntVariable : ScriptableObject
    {
        public int value;
        
        protected void OnEnable()
        {
            hideFlags |= HideFlags.DontUnloadUnusedAsset;
        }
    }
}