using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

public class AvatarGenerator : UnitySingletonPersistent<AvatarGenerator> {

	#region File Paths
	//Piece Paths
	const string HAIR_BACK_PATH = 	"Avatars/Pieces JSON/HairBacks";
	const string SHOULDER_PATH = 	"Avatars/Pieces JSON/Shoulders";
	const string CLOTHES_PATH = 	"Avatars/Pieces JSON/Clothes";
	const string HEAD_PATH = 		"Avatars/Pieces JSON/Heads";
	const string BEARD_PATH = 		"Avatars/Pieces JSON/Beards";
	const string MOUTH_PATH = 		"Avatars/Pieces JSON/Mouths";
	const string MOUSTACHE_PATH = 	"Avatars/Pieces JSON/Moustaches";
	const string NOSE_PATH = 		"Avatars/Pieces JSON/Noses";
	const string BROW_PATH =	 	"Avatars/Pieces JSON/Brows";
	const string EYE_PATH = 		"Avatars/Pieces JSON/Eyes";
	const string IRIS_PATH = 		"Avatars/Pieces JSON/Irises";
	const string PUPIL_PATH = 		"Avatars/Pieces JSON/Pupils";
	const string HAIR_FRONT_PATH = 	"Avatars/Pieces JSON/HairFronts";

	//Swatch Paths
	const string SKIN_SWATCH_PATH = "Avatars/Swatches JSON/Skin";
	const string HAIR_SWATCH_PATH = "Avatars/Swatches JSON/Hair";
	const string IRIS_SWATCH_PATH = "Avatars/Swatches JSON/Iris";
	const string CLOTHES_SWATCH_PATH = "Avatars/Swatches JSON/Clothes";
	#endregion

	#region Dictionary Declarations
	//Piece Dictionaries
	public Dictionary<string, AvatarPiece> hairBacks;
	public Dictionary<string, AvatarPiece> shoulders;
	public Dictionary<string, AvatarPiece> clothes;
	public Dictionary<string, AvatarPiece> heads;
	public Dictionary<string, AvatarPiece> beards;
	public Dictionary<string, AvatarPiece> mouths;
	public Dictionary<string, AvatarPiece> moustaches;
	public Dictionary<string, AvatarPiece> noses;
	public Dictionary<string, AvatarPiece> brows;
	public Dictionary<string, AvatarPiece> eyes;
	public Dictionary<string, AvatarPiece> irises;
	public Dictionary<string, AvatarPiece> pupils;
	public Dictionary<string, AvatarPiece> hairFronts;

	//Swatch Dictionaries
	public Dictionary<string, Swatch> skinSwatches;
	public Dictionary<string, Swatch> hairSwatches;
	public Dictionary<string, Swatch> irisSwatches;
	public Dictionary<string, Swatch> clothesSwatches;
	#endregion

	JsonSerializerSettings settings;

	public override void Awake(){
		OnAwake ();
		LoadAll ();

		//TestGenerateAvatar ();
	}

	#region Loading
	private void LoadAll(){
		settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.Objects;

		hairBacks =  LoadPieces(HAIR_BACK_PATH);
		shoulders =  LoadPieces(SHOULDER_PATH);
		clothes = 	 LoadPieces(CLOTHES_PATH);
		heads =		 LoadPieces(HEAD_PATH);
		beards =	 LoadPieces(BEARD_PATH);
		mouths = 	 LoadPieces(MOUTH_PATH);
		moustaches = LoadPieces(MOUSTACHE_PATH);
		noses =		 LoadPieces(NOSE_PATH);
		brows =		 LoadPieces(BROW_PATH);
		eyes =		 LoadPieces(EYE_PATH);
		irises =	 LoadPieces(IRIS_PATH);
		pupils = 	 LoadPieces(PUPIL_PATH);
		hairFronts = LoadPieces(HAIR_FRONT_PATH);

		skinSwatches = LoadSwatches(SKIN_SWATCH_PATH);
		hairSwatches = LoadSwatches(HAIR_SWATCH_PATH);
		irisSwatches = LoadSwatches(IRIS_SWATCH_PATH);
		clothesSwatches = LoadSwatches(CLOTHES_SWATCH_PATH);
	}

	private Dictionary<string, AvatarPiece> LoadPieces(string path){
		TextAsset pieceFile = Resources.Load<TextAsset>(path);
		return JsonConvert.DeserializeObject<Dictionary<string, AvatarPiece>>(pieceFile.text, settings);
	}

	private Dictionary<string, Swatch> LoadSwatches(string path){
		TextAsset swatchFile = Resources.Load<TextAsset>(path);
		return JsonConvert.DeserializeObject<Dictionary<string, Swatch>>(swatchFile.text, settings);
	}
	#endregion

	#region Generation
	public static void Generate(ref CharacterData cData){
		Instance.GenerateLocal(ref cData);
	}

	private void GenerateLocal(ref CharacterData cData){
		cData.avatar = new AvatarData();

		//NOTE: May need reordering once conflicts are implemented
		cData.avatar.AddPiece("Shoulders", 	GetRandomPiece(cData, shoulders));
		cData.avatar.AddPiece("Clothes", 	GetRandomPiece(cData, clothes));
		cData.avatar.AddPiece("Head", 		GetRandomPiece(cData, heads));
		cData.avatar.AddPiece("Beard", 		GetRandomPiece(cData, beards));
		cData.avatar.AddPiece("Mouth", 		GetRandomPiece(cData, mouths));
		cData.avatar.AddPiece("Moustache", 	GetRandomPiece(cData, moustaches));
		cData.avatar.AddPiece("Nose", 		GetRandomPiece(cData, noses));
		cData.avatar.AddPiece("Brows", 		GetRandomPiece(cData, brows));
		cData.avatar.AddPiece("Eyes", 		GetRandomPiece(cData, eyes));
		cData.avatar.AddPiece("Irises", 	GetRandomPiece(cData, irises));
		cData.avatar.AddPiece("Pupils", 	GetRandomPiece(cData, pupils));
		cData.avatar.AddPiece("HairFront",  GetRandomPiece(cData, hairFronts));
		cData.avatar.AddPiece("HairBack", 	GetRandomPiece(cData, hairBacks));

		cData.avatar.AddSwatch("Skin", GetRandomSwatch(cData, skinSwatches));
		cData.avatar.AddSwatch("Hair", GetRandomSwatch(cData, hairSwatches));
		cData.avatar.AddSwatch("Iris", GetRandomSwatch(cData, irisSwatches));
		cData.avatar.AddSwatch("Clothes", GetRandomSwatch(cData, clothesSwatches));

		//Random chance to mirror characters horizontally
		if(Random.value > .7f){
			cData.avatar.xScale = -1; 
		}
	}

	private AvatarPiece GetRandomPiece(CharacterData cData, Dictionary<string, AvatarPiece> dict){
		ProbabilityArray<AvatarPiece> pa = new ProbabilityArray<AvatarPiece>();

		foreach(KeyValuePair<string, AvatarPiece> kvp in dict){
			if(PieceMatchesAvatar(kvp.Value, cData.avatar)){
				pa.AddValue(kvp.Value, kvp.Value.weight);
			}
		}

		return pa.GetRandomValue();
	}

	private bool PieceMatchesAvatar(AvatarPiece piece, AvatarData avatar){
		if (piece.conflictingPieces.Count == 0 || !avatar.ContainsAnyPiece (piece.conflictingPieces)) {
			if (piece.requiredPieces.Count == 0 || avatar.ContainsAnyPiece (piece.requiredPieces)) {
				return true;
			}
		}

		return false;
	}

	private Swatch GetRandomSwatch(CharacterData cData, Dictionary<string, Swatch> dict){
		ProbabilityArray<Swatch> pa = new ProbabilityArray<Swatch>();

		foreach(KeyValuePair<string, Swatch> kvp in dict){
			//IF cData allows
			pa.AddValue(kvp.Value, kvp.Value.weight);
		}

		return pa.GetRandomValue();
	}
	#endregion

	#region Test Scene
	public void TestGenerateAvatar(){
		GameObject.Find("Avatar").GetComponent<AvatarSprite>().Setup(CharacterGenerator.Generate().avatar);
	}

	public float CountCombinations(){
		float faces = 1f;

		faces *= (hairBacks.Count - 1f);
		faces *= clothes.Count;
		faces *= (beards.Count - 1f);
		faces *= (mouths.Count - 1f);
		faces *= moustaches.Count;
		faces *= (noses.Count - 1f);
		faces *= brows.Count;
		faces *= (eyes.Count - 1f);
		faces *= hairFronts.Count;

		faces *= (skinSwatches.Count - 1f);
		faces *= (hairSwatches.Count - 1f);
		faces *= (irisSwatches.Count - 1f);
		faces *= clothesSwatches.Count;

		faces *= 2; //Horizontal flip

		return faces;
	}
	#endregion
}
