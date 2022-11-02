// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using Custom_Event_Types;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace RoboRyanTron.Unite2017.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        [SerializeField] private GameEventWithScriptable Event;
        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField] private UnityEvent Response;
        
        [SerializeField] private GameEventWithScriptable TwoBooleanEvent;
        [SerializeField] private TwoBooleanEvent TwoBoolResponse;
        
        [SerializeField] private GameEventWithScriptable Vector3Event;
        [SerializeField] private Vector3Event Vector3Response;
        
        [SerializeField] private GameEventWithScriptable StringEvent;
        [SerializeField] private StringEvent StringResponse;
        
        [SerializeField] private GameEventWithScriptable BoolEvent;
        [SerializeField] private BoolEvent BoolResponse;
        
        [SerializeField] private GameEventWithScriptable NavMeshEvent;
        [SerializeField] private NavMeshAgentEvent NavMeshResponse;
        
        [SerializeField] private GameEventWithScriptable TwoFloatEvent;
        [SerializeField] private TwoFloatEvent TwoFloatResponse;

        private void OnEnable()
        {
            if (Event != null)
            {
                Event.RegisterListener(this);
            }

            if (TwoBooleanEvent != null)
            {
                TwoBooleanEvent.RegisterListener(this);
            }
            
            if (Vector3Event != null)
            {
                Vector3Event.RegisterListener(this);
            }
            
            if (StringEvent != null)
            {
                StringEvent.RegisterListener(this);
            }
            
            if (BoolEvent != null)
            {
                BoolEvent.RegisterListener(this);
            }
            
            if (NavMeshEvent != null)
            {
                NavMeshEvent.RegisterListener(this);
            }
            
            if (TwoFloatEvent != null)
            {
                TwoFloatEvent.RegisterListener(this);
            }
        }
        
        private void OnDisable()
        {
            if (Event != null)
            {
                Event.UnregisterListener(this);
            }

            if (TwoBooleanEvent != null)
            {
                TwoBooleanEvent.UnregisterListener(this);
            }
            
            if (Vector3Event != null)
            {
                Vector3Event.UnregisterListener(this);
            }
            
            if (StringEvent != null)
            {
                StringEvent.UnregisterListener(this);
            }
            
            if (BoolEvent != null)
            {
                BoolEvent.UnregisterListener(this);
            }
            
            if (NavMeshEvent != null)
            {
                NavMeshEvent.UnregisterListener(this);
            }
            
            if (TwoFloatEvent != null)
            {
                TwoFloatEvent.UnregisterListener(this);
            }
        }

        public void OnEventRaised() => Response.Invoke();
        public void OnEventRaised(bool condition1, bool condition2) => TwoBoolResponse.Invoke(condition1, condition2);
        public void OnEventRaised(Vector3 xyzVector) => Vector3Response.Invoke(xyzVector);
        public void OnEventRaised(string text) => StringResponse.Invoke(text);
        public void OnEventRaised(bool condition) => BoolResponse.Invoke(condition);
        public void OnEventRaised(NavMeshAgent agent) => NavMeshResponse.Invoke(agent);
        public void OnEventRaised(float value1, float value2) => TwoFloatResponse.Invoke(value1, value2);

    }
}