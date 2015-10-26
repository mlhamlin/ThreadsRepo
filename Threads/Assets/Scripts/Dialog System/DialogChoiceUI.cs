using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogChoiceUI : MonoBehaviour
{
    public Text Line;
    DialogNode next;
    List<string> FlagsToSetTrue;
    List<string> FlagsToSetFalse;

    public void SetupChoice(DialogChoice.Choice choice)
    {
        Line.text = choice.playerChoiceLine;
        next = DialogDictionary.GetNode(choice.choiceResult);
        FlagsToSetFalse = choice.setFlagsFalse;
        FlagsToSetTrue = choice.setFlagsTrue;
    }

    public void OnSelect()
    {
        foreach(string s in FlagsToSetTrue)
        {
            GameStateDictionary.SetFlag(s, true);
        }

        foreach(string s in FlagsToSetFalse)
        {
            GameStateDictionary.SetFlag(s, false);
        }

        next.DisplayDialog();
    }
}
