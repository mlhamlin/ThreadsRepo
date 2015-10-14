using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateDummyDialog : MonoBehaviour {

    public bool generate = false;

	// Use this for initialization
	void Start () {
        if(generate)
        {
            DialogDictionary.SetNode(new SpokenLine("L1", "Shawn", "sly", "Shawn", "Huyu", "neutral", "Huyu", "This is a test...", true, "L2"));
            DialogDictionary.SetNode(new SpokenLine("L2", "Shawn", "crazy", "Shawn", "Huyu", "annoyed", "Huyu", "a very circular test", true, "L3"));
            DialogDictionary.SetNode(new SpokenLine("L3", "Shawn", "crazy", "Shawn", "Huyu", "angry", "Huyu", "Haven't you already said that?", false, "RL1"));

            List<string> possibleLines = new List<string>();
            possibleLines.Add("L4a");
            DialogDictionary.SetNode(new SpokenLine("L4a", "Shawn", "confused", "Shawn", "Huyu", "annoyed", "Huyu", "Have I? I can't seem to remember...", true, "L5a"));
            possibleLines.Add("L4b");
            DialogDictionary.SetNode(new SpokenLine("L4b", "Shawn", "confused", "Shawn", "Huyu", "annoyed", "Huyu", "Really?  Are you sure?", true, "L5b"));
            possibleLines.Add("L4c");
            DialogDictionary.SetNode(new SpokenLine("L4c", "Shawn", "confused", "Shawn", "Huyu", "annoyed", "Huyu", "Have I really?", true, "L5a"));
            DialogDictionary.SetNode(new RandomLine("RL1", possibleLines));

            DialogDictionary.SetNode(new SpokenLine("L5a", "Shawn", "sad", "Shawn", "Huyu", "mad", "Huyu", "YES YOU HAVE!", false, "L6"));
            DialogDictionary.SetNode(new SpokenLine("L5b", "Shawn", "sad", "Shawn", "Huyu", "mad", "Huyu", "YES!", false, "L6"));

            DialogDictionary.SetNode(new SpokenLine("L6", "Shawn", "neutral", "Shawn", "Huyu", "angry", "Huyu", "Please just stop.", false, "DC1"));

            List<DialogChoice.Choice> choices = new List<DialogChoice.Choice>();
            DialogChoice.Choice c1 = new DialogChoice.Choice();
            c1.playerChoiceLine = "Hmm... no!";
            c1.flag = "true";
            c1.setFlagsFalse = new List<string>();
            c1.setFlagsTrue = new List<string>();
            c1.setFlagsTrue.Add("SpokeOnce");
            DialogDictionary.SetNode(new SpokenLine("L8a", "Shawn", "neutral", "Shawn", "Huyu", "annoyed", "Huyu", "Darn it.", false, "L1"));
            c1.choiceResult = "L8a";
            choices.Add(c1);

            DialogChoice.Choice c2 = new DialogChoice.Choice();
            c2.playerChoiceLine = "Sure...";
            c2.flag = "true";
            c2.setFlagsFalse = new List<string>();
            c2.setFlagsTrue = new List<string>();
            c2.setFlagsTrue.Add("SpokeOnce");
            DialogDictionary.SetNode(new SpokenLine("L8b1", "Shawn", "neutral", "Shawn", "Huyu", "amazed", "Huyu", "Really?.", false, "L8b2"));
            c2.choiceResult = "L8b1";
            DialogDictionary.SetNode(new SpokenLine("L8b2", "Shawn", "pleased", "Shawn", "Huyu", "surprised", "Huyu", "Nope!", true, "L8b3"));
            DialogDictionary.SetNode(new SpokenLine("L8b3", "Shawn", "pleased", "Shawn", "Huyu", "annoyed", "Huyu", "darn it.", false, "L1"));
            choices.Add(c2);

            DialogChoice.Choice c3 = new DialogChoice.Choice();
            c3.playerChoiceLine = "Alright...";
            c3.flag = "SpokeOnce";
            c3.setFlagsFalse = new List<string>();
            c3.setFlagsTrue = new List<string>();
            c3.choiceResult = "L8c1";
            DialogDictionary.SetNode(new SpokenLine("L8c1", "Shawn", "neutral", "Shawn", "Huyu", "annoyed", "Huyu", "... for real this time?", false, "L8c2"));
            DialogDictionary.SetNode(new SpokenLine("L8c2", "Shawn", "sad", "Shawn", "Huyu", "surprised", "Huyu", "yeah... bye.", true, "L8c3"));
            DialogDictionary.SetNode(new SpokenLine("L8c3", "Shawn", "sad", "Shawn", "Huyu", "confused", "Huyu", "... bye.", false, "End"));
            choices.Add(c3);

            DialogDictionary.SetNode(new DialogChoice("DC1", "Shawn", "confused", "Shawn", "Huyu", "scared", "Huyu", choices));

            DialogDictionary.SetNode(new SpokenLine("C2L1", "Shawn", "sad", "Shawn", "Huyu", "neutral", "Huyu", "Can we talk?", true, "C2L2"));
            DialogDictionary.SetNode(new SpokenLine("C2L2", "Shawn", "sad", "Shawn", "Huyu", "annoyed", "Huyu", "No.", true, "End"));

            DialogDictionary.SetNode(new EndDialog());

            List<DialogBranch.ConversationOptions> conv = new List<DialogBranch.ConversationOptions>();
            DialogBranch.ConversationOptions con1 = new DialogBranch.ConversationOptions();
            con1.DialogNodeID = "L1";
            con1.flag = "true";
            conv.Add(con1);

            DialogBranch.ConversationOptions con2 = new DialogBranch.ConversationOptions();
            con2.DialogNodeID = "C2L1";
            con2.flag = "SpokeOnce";
            conv.Add(con2);

            DialogDictionary.SetNode(new DialogBranch("HuyuStart", conv));

            DialogDictionary.SaveDictionary();
        }
    }
}
