using UnityEngine;
using System.Collections.Generic;

public class RelationshipWeb : MonoBehaviour {

    public List<CharacterCore> members;
    
    public void Start()
    {
        if (members == null)
            members = new List<CharacterCore>();
    }

    public void JoinRelationship(CharacterCore newMember)
    {
        if(newMember.currentShipWeb != this)
        {
            ShipManager.Merge(this, newMember.currentShipWeb);
        }
    }
}
