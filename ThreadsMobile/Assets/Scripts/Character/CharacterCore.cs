using UnityEngine;
using System.Collections.Generic;

[RequireComponent (typeof(CharacterInteraction), typeof(CharacterData))]
public class CharacterCore : MonoBehaviour {

    public List<CharacterCore> Partners;

    public RelationshipWeb currentShipWeb;

    private CharacterData data;
    private CharacterInteraction interaction;
    private CharacterAvatar avatar;
    public CharacterHappiness happiness;
    
    // Use this for initialization
    void Start () {}

	public void setCharacterData(CharacterData characterData) {
		currentShipWeb = ShipManager.SetUpWeb();
		currentShipWeb.members.Add(this);
		interaction = GetComponent<CharacterInteraction>();
		happiness = GetComponent<CharacterHappiness>();
		data = characterData;

		if (data == null) {
			data = CharacterGenerator.Generate ();
		} else {
			data = CharacterGenerator.GenerateAvatar (data);
		}
		interaction.Setup(this, data);
		ScoreRelationships();
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

        happiness.score = score;

		return score;
	}
}
