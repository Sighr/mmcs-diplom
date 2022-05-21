using System.Collections.Generic;
using UnityEngine;

namespace ColliderSystem
{
    public class CollisionsList : MonoBehaviour
    {
        public List<Collision> currentCollisionsList = new();
        private void OnCollisionEnter(Collision collision)
        {
            // TODO: layer based collision detection
            currentCollisionsList.Add(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            currentCollisionsList.Remove(collision);
        }
    }
}