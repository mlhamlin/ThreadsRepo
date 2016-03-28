using UnityEngine;
using System.Collections.Generic;

public class ShipLinesManager : UnitySingleton<ShipLinesManager> {

	private List<RelationshipLine> lines;

    public delegate void CloseUI();

    public CloseUI closeAllUI;

	public void Awake()
	{
		lines = new List<RelationshipLine>();
	}

	public static void resetShips() {
        
        //Debug.Log("Reset Ships");
        int count = Instance.lines.Count;
		for (int i = 0; i < count; i++) {
			RelationshipLine ship = Instance.lines [i];
            if(ship != null)
            {
                ship.BreakUp(true);
            }
		}

        if (Instance.closeAllUI != null)
        {
            Instance.closeAllUI();
        }

        Instance.lines.Clear ();
	}

	public static void addShip(RelationshipLine line) {
		line.transform.SetParent(Instance.transform);
		Instance.lines.Add (line);
	}

	public static void breakShip(RelationshipLine line) {
		Instance.lines.Remove (line);
	}

}
