using UnityEngine;
using System.Collections;

public class AvatarSprite : MonoBehaviour {

	public SpriteRenderer hairBack;
	public SpriteRenderer shoulders;
	public SpriteRenderer head;
	public SpriteRenderer mouth;
	public SpriteRenderer nose;
	public SpriteRenderer brows;
	public SpriteRenderer eyes;
	public SpriteRenderer irises;
	public SpriteRenderer pupils;
	public SpriteRenderer hairFront;

	public void Setup(AvatarData data){
		SetupPiece(data, hairBack,	data.GetPiece("HairBack"));
		SetupPiece(data, shoulders,	data.GetPiece("Shoulders"));
		SetupPiece(data, head,		data.GetPiece("Head"));
		SetupPiece(data, mouth,		data.GetPiece("Mouth"));
		SetupPiece(data, nose,		data.GetPiece("Nose"));
		SetupPiece(data, brows,		data.GetPiece("Brows"));
		SetupPiece(data, eyes,		data.GetPiece("Eyes"));
		SetupPiece(data, irises,	data.GetPiece("Irises"));
		SetupPiece(data, pupils,	data.GetPiece("Pupils"));
		SetupPiece(data, hairFront,	data.GetPiece("HairFront"));

		transform.localScale = new Vector3 (data.xScale, 1, 1);
	}

	private void SetupPiece(AvatarData data, SpriteRenderer sr, AvatarPiece piece){
		if(piece != null && piece.path != null){
			sr.sprite = Resources.Load<Sprite>("Avatars/" + piece.path);
			sr.color = data.GetSwatch(piece.swatchType).GetColor();
		}
	}
}
