using System.Collections.Generic;

public class DialogBranch : DialogNode
{
    public struct ConversationOption
    {
        public string flag;
        public string DialogNodeID;
    }

    public List<ConversationOption> options;

    public DialogBranch(string ID, List<ConversationOption> convOptions)
    {
        NodeID = ID;
        options = convOptions;
    }

    public override void DisplayDialog()
    {
        string choice = "";

        foreach(ConversationOption c in options)
        {
            if(GameStateDictionary.CheckFlag(c.flag))
            {
                choice = c.DialogNodeID;
            }
        }

        DialogDictionary.GetNode(choice).DisplayDialog();
    }
}
