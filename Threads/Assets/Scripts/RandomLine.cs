using UnityEngine;
using System.Collections.Generic;

public class RandomLine : DialogNode {

    List<string> LineOptions;

    public RandomLine(string ID, List<string> PossibleLines)
    {
        NodeID = ID;
        LineOptions = PossibleLines;
    }

    public override void DisplayDialog()
    {
        DialogNode node = DialogDictionary.GetNode(LineOptions[Random.Range(0, LineOptions.Count)]);
        node.DisplayDialog();
    }
}
