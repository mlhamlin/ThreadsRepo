using UnityEngine;
using System.Collections;

public class AvatarTestExport : MonoBehaviour {


	public void Export(){
		RenderTexture renderTex = Resources.Load<RenderTexture>("AvatarRenderTexture") as RenderTexture;

		Texture2D tex2d = new Texture2D (256, 256);

		tex2d.ReadPixels (new Rect (0, 0, renderTex.width, renderTex.height), 0, 0);
		tex2d.Apply ();
	}
}
