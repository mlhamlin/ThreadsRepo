using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarPiece {

	public string id;
	public string path;
	public string swatchType;
	public float weight;

	public float male = 1f;
	public float female = 1f;

	public List<string> requiredPieces = new List<string>();
	public List<string> conflictingPieces = new List<string>();
}
