using UnityEngine;
using System.Collections;

public class GoAwayThreadHack : MonoBehaviour {

    public Thread thread;
    public string flag;
	
	// Update is called once per frame
	void Update () {
        thread.setVisibility(!GameStateDictionary.CheckFlag(flag));
	}
}
