using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    [CreateAssetMenu(fileName = "Event", menuName = "SO/Event")]
    public class Event : ScriptableObject
    {
        private readonly List<EventListener> listeners = new();
    
        public void RaiseEvent()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }
    
        public void RegisterListener(EventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }
    
        public void UnregisterListener(EventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}