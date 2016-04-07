using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject gameManager = GameObject.Find ("GameManager");
		if (Application.isEditor && gameManager == null) {
			SceneManager.LoadScene("Title");
		} else {
			Destroy(gameObject);
		}
	}
}
