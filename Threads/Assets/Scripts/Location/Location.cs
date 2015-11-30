using UnityEngine;
using System.Collections.Generic;

public class Location : MonoBehaviour {

    public BoxCollider2D AreaExternal;
    //background music
    //background sounds
    public bool active;
    public List<TeleportZone> exitPoints; //auto gen from children?
    public List<Transform> entryPoints; //auto gen from children?

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
