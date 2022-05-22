using UnityEngine;

namespace ColliderSystem
{
    [RequireComponent(typeof(Unit))]
    public class CollisionsDetector : MonoBehaviour
    {
        private Unit _unit;
        
        private void Start()
        {
            _unit = GetComponent<Unit>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _unit.components.currentCollisions.Add(collision.gameObject);
        }

        private void OnCollisionExit(Collision collision)
        {
            _unit.components.currentCollisions.Remove(collision.gameObject);
        }
    }
}