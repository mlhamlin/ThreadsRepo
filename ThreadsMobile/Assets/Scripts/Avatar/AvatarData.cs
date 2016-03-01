using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarData {

	Dictionary<string, AvatarPiece> pieces;
	Dictionary<string, Swatch> swatches;

	public AvatarPiece GetPiece(string id){
		AvatarPiece value;

		if(pieces.TryGetValue(id.ToLower(), out value)){
			return value;
		}else{
			Debug.LogError("Avatar Piece '" + id + "' not found");
			return new AvatarPiece();
		}
	}

	public Swatch GetSwatch(string id){
		Swatch value;

		if(swatches.TryGetValue(id.ToLower(), out value)){
			return value;
		}else{
			Debug.LogError("Swatch '" + id + "' not found");
			return new Swatch();
		}
	}

	public void AddPiece(string pieceType, AvatarPiece piece){
		pieces.Add(pieceType.ToLower(), piece);
	}

	public void AddSwatch(string swatchType, Swatch swatch){
		swatches.Add(swatchType.ToLower(), swatch);
	}

	public AvatarData(){
		pieces = new Dictionary<string, AvatarPiece>();
		swatches = new Dictionary<string, Swatch>();

		AddSwatch("Default", Swatch.GetDefaultSwatch());
	}
}
