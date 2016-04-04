using UnityEngine;
using System.Collections;

public class AvatarSprite : MonoBehaviour {

	public SpriteRenderer hairBack;
	public SpriteRenderer shoulders;
	public SpriteRenderer clothes;
	public SpriteRenderer head;
	public SpriteRenderer ears;
	public SpriteRenderer beard;
	public SpriteRenderer mouth;
	public SpriteRenderer moustache;
	public SpriteRenderer nose;
	public SpriteRenderer brows;
	public SpriteRenderer eyes;
	public SpriteRenderer irisLeft;
	public SpriteRenderer irisRight;
	public SpriteRenderer pupils;
	public SpriteRenderer lenses;
	public SpriteRenderer frames;
	public SpriteRenderer hairFront;

	public AvatarData avatarData;

	public void Setup(AvatarData data){
		avatarData = data;

		SetupPiece(data, hairBack,	data.GetPiece("HairBack"));
		SetupPiece(data, shoulders,	data.GetPiece("Shoulders"));
		SetupPiece(data, clothes,	data.GetPiece("Clothes"));
		SetupPiece(data, head,		data.GetPiece("Head"));
		SetupPiece(data, ears,		data.GetPiece("Ears"));
		SetupPiece(data, beard,		data.GetPiece("Beard"));
		SetupPiece(data, mouth,		data.GetPiece("Mouth"));
		SetupPiece(data, moustache,	data.GetPiece("Moustache"));
		SetupPiece(data, nose,		data.GetPiece("Nose"));
		SetupPiece(data, brows,		data.GetPiece("Brows"));
		SetupPiece(data, eyes,		data.GetPiece("Eyes"));
		SetupPiece(data, irisLeft,	data.GetPiece("Iris Left"));
		SetupPiece(data, irisRight,	data.GetPiece("Iris Right"));
		SetupPiece(data, pupils,	data.GetPiece("Pupils"));
		SetupPiece(data, lenses,	data.GetPiece("Lenses"));
		SetupPiece(data, frames,	data.GetPiece("Frames"));
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
