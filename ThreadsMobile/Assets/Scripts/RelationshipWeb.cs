using UnityEngine;
using System.Collections.Generic;

public class RelationshipWeb : MonoBehaviour {

    public List<CharacterData> members;
    
    public void Start()
    {
        if (members == null)
            members = new List<CharacterData>();
    }

    public void JoinRelationship(CharacterData newMember)
    {
        if(newMember.currentShipWeb != this)
        {
            ShipManager.Merge(this, newMember.currentShipWeb);
        }
    }
}
