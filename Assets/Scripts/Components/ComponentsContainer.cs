using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class ComponentsContainer
    {
        public readonly HashSet<GameObject> currentCollisions = new();
    }
}