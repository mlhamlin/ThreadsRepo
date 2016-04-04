using UnityEngine;
using System.Collections;

public class AvatarTestExport : MonoBehaviour {

	public CanvasGroup uiRoot;
	public AvatarSprite avatarSprite;

	public void Export(){
		RenderTexture renderTex = Resources.Load<RenderTexture>("AvatarRenderTexture") as RenderTexture;

		Texture2D tex2d = new Texture2D (256, 256);

		tex2d.ReadPixels (new Rect (0, 0, renderTex.width, renderTex.height), 0, 0);
		tex2d.Apply ();
	}

	public void Screenshot(){
		uiRoot.alpha = 0;
		//Debug.Log (Application.persistentDataPath);
		string avatarID = "" + avatarSprite.avatarData.seed;
		Application.CaptureScreenshot (Application.persistentDataPath + "/avatar" + avatarID + ".png", 4);
		StartCoroutine ("PostScreenshotDelay");
	}

	IEnumerator PostScreenshotDelay(){
		yield return new WaitForSeconds (.005f);
		uiRoot.alpha = 1;
	}
}
