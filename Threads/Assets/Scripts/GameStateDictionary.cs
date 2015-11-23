using System.Collections.Generic;
using UnityEngine;

public class GameStateDictionary : UnitySingletonPersistent<GameStateDictionary>
{
    //TODO: Save/Load GameState

    //hmmm or should I have a single delegate sign up and pass flag and value?
    public delegate void stateChangeCallback(bool value);

    Dictionary<string, bool> flags;
    Dictionary<string, List<stateChangeCallback>> flagCallbacks;

    public void Start()
    {
        flags = new Dictionary<string, bool>();
        flags.Add("true", true);
        flags.Add("false", false);
        flagCallbacks = new Dictionary<string, List<stateChangeCallback>>();
    }

    public static bool CheckFlag(string flag)
    {
        bool value;
        if (Instance.flags.TryGetValue(flag, out value))
        {
            return value;
        }
        return false;
    }

    public static void SetFlag(string flag, bool value)
    {
        if ((flag == "true") || (flag == "false"))
        {
            Debug.LogError("Attempted to set value for true or false protected flag.");
            return;
        }

        Instance.flags[flag] = value;

        if(Instance.flagCallbacks.ContainsKey(flag))
        {
            foreach(stateChangeCallback callback in Instance.flagCallbacks[flag])
            {
                callback(value);
            }
        }
    }

    public static void RegisterCallback(string flag, stateChangeCallback callback)
    {
        if(!Instance.flagCallbacks.ContainsKey(flag))
        {
            Instance.flagCallbacks[flag] = new List<stateChangeCallback>();
        }

        Instance.flagCallbacks[flag].Add(callback);
    }

    public static void DeregisterCallback(string flag, stateChangeCallback callback)
    {
        if(Instance.flagCallbacks.ContainsKey(flag))
        {
            Instance.flagCallbacks[flag].Remove(callback);
        }
    }
}
