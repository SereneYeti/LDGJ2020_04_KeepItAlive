using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EVENT_TYPE
{
    GAME_INIT,
    GAME_END,
    AMMO_CHANGE,
    HEALTH_CHANGE,
    DEATH
};

public class EventManager : MonoBehaviour
{
    private static EventManager instance;

    public static EventManager Instance
    {
        get { return instance; }
        set { }
    }

    public delegate void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null);

    private Dictionary<EVENT_TYPE, List<OnEvent>> Listeners = new Dictionary<EVENT_TYPE, List<OnEvent>>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddListener(EVENT_TYPE Event_Type, OnEvent Listener)
    {
        List<OnEvent> ListenList = null;

        if (Listeners.TryGetValue(Event_Type, out ListenList))
        {
            ListenList.Add(Listener);
            return;
        }

        ListenList = new List<OnEvent>();
        ListenList.Add(Listener);
        Listeners.Add(Event_Type, ListenList);
    }

    public void PostNotification(EVENT_TYPE Event_Type, Component Sender, object Param = null)
    {
        List<OnEvent> ListenList = null;

        if (!Listeners.TryGetValue(Event_Type, out ListenList))
            return;

        foreach (OnEvent onEvent in ListenList)
        {
            if (!onEvent.Equals(null))
            {
                onEvent(Event_Type, Sender, Param);
            }
        }

    }

    public void RemoveEvent(EVENT_TYPE Event_Type)
    {
        Listeners.Remove(Event_Type);
    }

}

