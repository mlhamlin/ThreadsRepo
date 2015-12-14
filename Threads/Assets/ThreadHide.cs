using UnityEngine;
using System.Collections;

public class ThreadHide : MonoBehaviour {

    public Thread thread;
    public string[] flags;
    public boolOp Operator;
    public enum boolOp
    {
        and, or
    }
    public behavior whenSatisfied;
    public enum behavior
    {
        show, hide
    }

	// Use this for initialization
	void Start () {
        foreach(string flag in flags)
        {
            GameStateDictionary.RegisterCallback(flag, StateChange);
        }
    }

    public void StateChange(bool val)
    {
        if(behavior.show == whenSatisfied)
        {
            thread.setVisibility(isSatisfied());
        }
        else
        {
            thread.setVisibility(!isSatisfied());
        }

    }

    public bool isSatisfied()
    {
        if (boolOp.and == Operator)
        {
            foreach(string flag in flags)
            {
                if (!GameStateDictionary.CheckFlag(flag))
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            foreach(string flag in flags)
            {
                if(GameStateDictionary.CheckFlag(flag))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
