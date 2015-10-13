using System.Collections.Generic;

public class GameStateDictionary : UnitySingletonPersistent<GameStateDictionary>
{

    Dictionary<string, bool> flags;

    public void Start()
    {
        flags = new Dictionary<string, bool>();
        flags.Add("true", true);
        flags.Add("false", false);
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
        Instance.flags[flag] = value;
    }
}
