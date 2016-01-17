using UnityEngine;
using System.Collections.Generic;

public class TraitManager : MonoBehaviour {

    public struct Trait
    {
        string traitName;
        string traitDescription;
        string icon;

        public Trait(string traitName, string traitDescription, string icon) : this()
        {
            this.traitName = traitName;
            this.traitDescription = traitDescription;
            this.icon = icon;
        }
    }

    public Dictionary<int, Trait> traitNames;

	// Use this for initialization
	void Start () {
        traitNames = new Dictionary<int, Trait>();
        traitNames.Add(0, new Trait("Funny", "blah", "Funny"));
        traitNames.Add(1, new Trait("Smart", "blah", "Smart"));
        traitNames.Add(2, new Trait("Geeky", "blah", "Geeky"));
        traitNames.Add(3, new Trait("Athletic", "blah", "Athletic"));
        traitNames.Add(4, new Trait("Sports Fan", "blah", "SportsFan"));
        traitNames.Add(5, new Trait("Caring", "blah", "Caring"));
        traitNames.Add(100, new Trait("Cis Man", "blah", "cisman"));
        traitNames.Add(101, new Trait("Trans Man", "blah", "mtf"));
        traitNames.Add(200, new Trait("Cis Woman", "blah", "ciswoman"));
        traitNames.Add(201, new Trait("Trans Woman", "blah", "ftm"));
    }

    // Update is called once per frame
    void Update () {
	
	}
}
