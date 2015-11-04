using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Thread : MonoBehaviour {

    public List<SpriteRenderer> threadImages;

    public void setVisibility(bool visible)
    {
        foreach(SpriteRenderer sp in threadImages)
        {
            sp.enabled = visible;
        }
    }
}
