using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarData {

	Dictionary<string, AvatarPiece> pieces;
	Dictionary<string, Swatch> swatches;

	public int xScale = 1;

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

	public bool ContainsAnyPiece(List<string> ids){
		foreach(string id in ids){
			if(id != null && ContainsPiece(id)){
				return true;
			}
		}
		return false;
	}

	public bool ContainsPiece(string id){
		foreach(KeyValuePair<string, AvatarPiece> kvp in pieces){
			if(kvp.Value.id != null && kvp.Value.id == id){
				return true;
			}
		}
		return false;
	}

	public AvatarData(){
		pieces = new Dictionary<string, AvatarPiece>();
		swatches = new Dictionary<string, Swatch>();

		AddSwatch("Default", Swatch.GetDefaultSwatch());
	}
}
