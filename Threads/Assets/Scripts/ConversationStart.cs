using System.Collections.Generic;

public class ConversationStart
{
    public struct conversations
    {
        public string flag;
        public DialogNode conversation;
    }

    List<conversations> starts;
    //run the dialog node which matches the first true flag
    //ALTERNATE:  Run dialog node which matches last true flag?
    //TODO: Finish
}
