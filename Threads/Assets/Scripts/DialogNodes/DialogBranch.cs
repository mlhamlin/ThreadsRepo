using System.Collections.Generic;

public class DialogBranch : DialogNode
{
    public struct ConversationOptions
    {
        public string flag;
        public string DialogNodeID;
    }

    public List<ConversationOptions> options;

    public DialogBranch(string ID, List<ConversationOptions> convOptions)
    {
        NodeID = ID;
        options = convOptions;
    }

    public override void DisplayDialog()
    {
        string choice = "";

        foreach(ConversationOptions c in options)
        {
            if(GameStateDictionary.CheckFlag(c.flag))
            {
                choice = c.DialogNodeID;
            }
        }

        DialogDictionary.GetNode(choice).DisplayDialog();
    }
}
