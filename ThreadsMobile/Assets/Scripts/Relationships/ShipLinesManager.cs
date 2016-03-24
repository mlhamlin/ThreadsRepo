using UnityEngine;
using System.Collections.Generic;

public class ShipLinesManager : UnitySingleton<ShipLinesManager> {

	private List<RelationshipLine> lines;

	public void Awake()
	{
		lines = new List<RelationshipLine>();
	}

	public static void resetShips() {
		int count = Instance.lines.Count;
		for (int i = 0; i < count; i++) {
			RelationshipLine ship = Instance.lines [0];
            if(ship != null)
            {
                ship.BreakUp();
            }
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
