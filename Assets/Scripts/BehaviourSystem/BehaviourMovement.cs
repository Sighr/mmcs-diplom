using UnityEngine;

namespace BehaviourSystem
{
    public class BehaviourMovement
    {
        public static BehaviourMovement Stay = new()
        {
            DesiredMovement = Vector3.zero
        };
        public Vector3 DesiredMovement;
    }
}