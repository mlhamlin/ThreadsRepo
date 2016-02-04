using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof(CharacterInteraction), typeof(CharacterData))]
public class CharacterCore : MonoBehaviour {

    public List<CharacterCore> PlatonicPartners;
    public List<CharacterCore> RomanticPartners;
    public List<CharacterCore> SexualPartners;

    public RelationshipWeb currentShipWeb;

    private CharacterData data;
    private CharacterInteraction interaction;
    private CharacterAvatar avatar;
    
    // Use this for initialization
    void Start () {
        currentShipWeb = ShipManager.SetUpWeb();
        currentShipWeb.members.Add(this);
        Setup();
	}

    public void Setup()
    {
        data = new CharacterData();
        interaction = GetComponent<CharacterInteraction>();
        interaction.SetExternalConnections(this);
    }
}
