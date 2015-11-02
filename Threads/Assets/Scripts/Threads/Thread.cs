using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Thread : MonoBehaviour {

    public List<SpriteRenderer> threadImages;
    public Character character1;
    public Character character2;
    private bool registered = false;

	// Use this for initialization
	void Start () {
	}

    public void Update()
    {
        if(!registered)
        {
            ThreadDisplayManager.RegisterThread(this);
            registered = true;
            setVisibility(false);
        }
    }

    public void setVisibility(bool visible)
    {
        foreach(SpriteRenderer sp in threadImages)
        {
            sp.enabled = visible;
        }
    }
}
