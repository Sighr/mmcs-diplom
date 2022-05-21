using UnityEngine;
using UnityEngine.Events;

namespace EventSystem
{
    public class EventListener : MonoBehaviour
    {
        public Event gameEvent;
        public UnityEvent unityEvent;

        public void OnEventRaised()
        {
            unityEvent.Invoke();
        }

        public void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }
    
        public void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }
    }
}