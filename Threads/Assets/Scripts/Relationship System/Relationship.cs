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

        RelationshipNetwork.RegisterRelationship(this);
        GameStateDictionary.RegisterCallback(C1ShippingFlag, Char1ShippingCallback);
        GameStateDictionary.RegisterCallback(C2ShippingFlag, Char2ShippingCallback);
    }

    public void Char1ShippingCallback(bool value)
    {
        Char1ShippingIt = value;
        Recalculate();
    }

    public void Char2ShippingCallback(bool value)
    {
        Char2ShippingIt = value;
        Recalculate();
    }

    private void Recalculate()
    {
        Canon = Char1ShippingIt && Char2ShippingIt;
        RelationshipNetwork.Instance.RecalculateHappiness();
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

    public void SetThreadVisibility(bool active)
    {
        ourThread.setVisibility(active);
    }
}
