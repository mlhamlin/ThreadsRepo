using UnityEngine;
using System.Collections.Generic;

public class RelationshipWeb : MonoBehaviour {

    public List<CharacterData> members;

	// Use this for initialization
	void Start () {
	
	}

    public void JoinRelationship(CharacterData newMember)
    {
        if(newMember.currentShipWeb != this)
        {
            WebManager.Merge(this, newMember.currentShipWeb);
        }
    }
}
