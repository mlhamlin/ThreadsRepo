using UnityEngine;

public class Relationship : MonoBehaviour {

    public int Quality;
    public Character Char1;
    public Character Char2;
    public Thread ourThread;
    public bool Char1ShippingIt = false;
    public string C1ShippingFlag;
    public bool Char2ShippingIt = false;
    public string C2ShippingFlag;
    public bool Canon { get; private set; }

	// Use this for initialization
	void Start () {
	    if (Char2 == Character.NoOne)
        {
            Char2ShippingIt = true;
            C2ShippingFlag = "true";
        }
	}
	
	// Update is called once per frame
	void Update () {
        //TODO: Fix Temp Hack
        Char1ShippingIt = GameStateDictionary.CheckFlag(C1ShippingFlag);
        Char2ShippingIt = GameStateDictionary.CheckFlag(C2ShippingFlag);

        Canon = Char1ShippingIt && Char2ShippingIt;
	}

    public bool Contains(Character chr)
    {
        return (Char1 == chr) || (Char2 == chr);
    }

    public bool Contains(Character chr, Character chr2)
    {
        return ((Char1 == chr) || (Char2 == chr)) &&
                ((Char1 == chr2) || (Char2 == chr2));
    }

    public void SetShippingIt(Character chr, bool intoIt)
    {
        if (Char1 == chr)
        {
            Char1ShippingIt = intoIt;
        } else if (Char2 == chr)
        {
            Char2ShippingIt = intoIt;
        }
    }

    public void SetThreadVisibility(bool active)
    {
        ourThread.setVisibility(active);
    }
}
