using UnityEngine;
using System.Collections;
//using UnityEditor;

public class AvatarTestShowFolder : MonoBehaviour {

	public void ShowFolder(){
		string itemPath = Application.persistentDataPath;
		//itemPath = itemPath.Replace(@"/", @"\");   // explorer doesn't like front slashes
		//System.Diagnostics.Process.Start("explorer.exe", "/select,"+itemPath);
		//EditorUtility.RevealInFinder (itemPath);
	}
}
