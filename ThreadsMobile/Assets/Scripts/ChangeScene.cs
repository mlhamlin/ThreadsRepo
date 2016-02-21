using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
