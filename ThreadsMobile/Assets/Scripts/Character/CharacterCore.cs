using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof(CharacterInteraction), typeof(CharacterData))]
public class CharacterCore : MonoBehaviour {

    public List<CharacterCore> Partners;

    public RelationshipWeb currentShipWeb;

    private CharacterData data;
    private CharacterInteraction interaction;
    private CharacterAvatar avatar;

    public int HappyScore;
    
    // Use this for initialization
    void Start () {
        currentShipWeb = ShipManager.SetUpWeb();
        currentShipWeb.members.Add(this);
        Setup();
	}

    public void Setup()
    {
        data = CharacterGenerator.Generate();
       
        interaction = GetComponent<CharacterInteraction>();
        interaction.Setup(this, data);
    }

	private void PrintCharacterDataInfo()
	{
		data.PrintInfo ();
	}

	public int ScoreRelationships() {
		int score = 0;

		int polyMonoModifier = 0;

		foreach(Trait t in data.GetAllTraits()){
			polyMonoModifier += t.ScoreMonoPoly (currentShipWeb.MemberCount());
		}

		foreach (CharacterCore character in this.Partners) {
			score += this.data.ScoreRelationship (character.data);
			score += polyMonoModifier;
		}

        if (this.Partners.Count > 0)
        {
            score = score / this.Partners.Count;
        }

        HappyScore = score;

		return score;
	}
}
