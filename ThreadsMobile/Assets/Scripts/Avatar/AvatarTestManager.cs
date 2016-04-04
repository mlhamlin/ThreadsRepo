using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AvatarTestManager : MonoBehaviour {

	public AvatarSprite sprite;
	public InputField seedField;
	public Text tempSeedDisplay;

	/*
	public void GenerateFromSeed(){
		CharacterData character = CharacterGenerator.Generate ();
		sprite.Setup(character.avatar);
		AvatarTestGenderDisplay.Instance.UpdateText (character);
		seedField.text = character.avatar.seed;
	}*/

	public void Generate(){
		CharacterData character = CharacterGenerator.Generate ();
		sprite.Setup(character.avatar);
		AvatarTestGenderDisplay.Instance.UpdateText (character);
		tempSeedDisplay.text = "Seed: " + character.avatar.seed;
	}
}
