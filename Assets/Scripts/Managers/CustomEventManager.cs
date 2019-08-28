using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomEventManager : Singleton<CustomEventManager>
{
    private Dictionary<string, Delegate> m_eventDictionary;

    public CustomEventManager()
    {
        m_eventDictionary = new Dictionary<string, Delegate>();
    }

    public void OnDestroy()
    {
        m_eventDictionary.Clear();
    }

    public void StartListening(string eventName, Action listener)
    {
        Delegate thisEvent;
        if (m_eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            //Add more event to the existing one
            Action thisAction = thisEvent as Action;
            thisAction += listener;

            //Update the Dictionary
            m_eventDictionary[eventName] = thisAction;
        }
        else
        {
            //Add event to the Dictionary for the first time
            Action thisAction = new Action(listener);
            m_eventDictionary.Add(eventName, thisAction);
        }
    }
    public void StartListening<T>(string eventName, Action<T> listener)
    {
        Delegate thisEvent;
        if (m_eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            //Add more event to the existing one
            Action<T> thisAction = thisEvent as Action<T>;
            thisAction += listener;

            //Update the Dictionary
            m_eventDictionary[eventName] = thisAction;
        }
        else
        {
            //Add event to the Dictionary for the first time
            Action<T> thisAction = new Action<T>(listener);
            m_eventDictionary.Add(eventName, thisAction);
        }
    }

    public void StopListening(string eventName, Action listener)
    {
        Delegate thisEvent;
        if (m_eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            if (thisEvent != null)
            {
                //Remove event from the existing one
                Action thisAction = thisEvent as Action;
                thisAction -= listener;

                //Update the Dictionary
                Instance.m_eventDictionary[eventName] = thisAction;
            }
        }
    }
    public void StopListening<T>(string eventName, Action<T> listener)
    {
        Delegate thisEvent;
        if (m_eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            if (thisEvent != null)
            {
                //Remove event from the existing one
                Action<T> thisAction = thisEvent as Action<T>;
                thisAction -= listener;

                //Update the Dictionary
                Instance.m_eventDictionary[eventName] = thisAction;
            }
        }
    }

    public void TriggerEvent(string eventName)
    {
        Delegate thisEvent = null;
        if (m_eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            Action thisAction = thisEvent as Action;
            thisAction.Invoke();
            // OR USE instance.eventDictionary[eventName]();
        }
    }

    public void TriggerEvent<T>(string eventName, T param1)
    {
        Delegate thisEvent = null;
        if (m_eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            Action<T> thisAction = thisEvent as Action<T>;
            thisAction.Invoke(param1);
            // OR USE instance.eventDictionary[eventName]();
        }
    }
}
