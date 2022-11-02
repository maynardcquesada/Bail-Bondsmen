// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RoboRyanTron.Unite2017.Events
{
    [CreateAssetMenu(fileName = "Game Event With Scriptable", menuName = "ScriptableObjects/Game Event With Scriptable", order = 4)]
    public class GameEventWithScriptable : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener> eventListeners = 
            new List<GameEventListener>();

        public void Raise()
        {
            for(var i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
        }
        
        public void Raise(bool condition1, bool condition2)
        {
            for(var i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised(condition1, condition2);
        }
        
        public void Raise(Vector3 xyzVector)
        {
            for(var i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised(xyzVector);
        }
        
        public void Raise(string text)
        {
            for(var i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised(text);
        }
        
        public void Raise(bool condition)
        {
            for(var i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised(condition);
        }
        
        public void Raise(NavMeshAgent agent)
        {
            for(var i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised(agent);
        }
        
        public void Raise(float value1, float value2)
        {
            for(var i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised(value1, value2);
        }

        public virtual void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public virtual void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}