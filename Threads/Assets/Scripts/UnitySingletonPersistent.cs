using UnityEngine;
using System.Collections;

public class UnitySingletonPersistent<T> : MonoBehaviour
	where T : Component
{
	private static T instance;
	public static T Instance {
		get {
			if (applicationIsQuitting) {
				Debug.LogWarning("Application is quitting cannot access Singleton '"+ typeof(T) +"'.");
				return null;
			}
			
			if (instance == null) {
				T[] objs = FindObjectsOfType<T>();
				
				if (objs.Length > 0) {
					instance = objs[0];
				}
				
				if (objs.Length > 1) {
					Debug.LogError ("There is more than one " + typeof(T).Name + " in the scene.");
				}
				
				if (instance == null) {
					GameObject obj = new GameObject ();
					obj.hideFlags = HideFlags.HideAndDontSave;
					instance = obj.AddComponent<T> ();
				}
			}
			return instance;
		}
	}
	
	public virtual void Awake ()
	{
        OnAwake();
	}

    protected void OnAwake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	private static bool applicationIsQuitting = false;

	public void OnApplicationQuit () {
		applicationIsQuitting = true;
	}
}