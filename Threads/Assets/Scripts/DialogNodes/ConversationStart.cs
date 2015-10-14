using System.Collections.Generic;

public class ConversationStart : DialogNode
{
    //should this be a dialog node? probably not should be on the character
    public struct Conversation
    {
        public string flag;
        public string DialogNodeID;
    }

    public List<Conversation> starts;

    public ConversationStart(string ID, List<Conversation> conversationStarts)
    {
        NodeID = ID;
        starts = conversationStarts;
    }

    public override void DisplayDialog()
    {
        string choice = "";

        foreach(Conversation c in starts)
        {
            if(GameStateDictionary.CheckFlag(c.flag))
            {
                choice = c.DialogNodeID;
            }
        }

        DialogController.Instance.startConversation(choice);
    }
}
