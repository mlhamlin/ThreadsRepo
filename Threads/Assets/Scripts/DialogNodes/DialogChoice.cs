using System.Collections.Generic;

public class DialogChoice : DialogNode
{
    public struct Choice
    {
        public string flag;
        public string playerChoiceLine;
        public string choiceResult;
        public List<string> setFlagsFalse;
        public List<string> setFlagsTrue;
    }

    public string Char1FolderName;
    public string Char1ProfileEmotion;
    public string Char1DisplayName;

    public string Char2FolderName;
    public string Char2ProfileEmotion;
    public string Char2DisplayName;

    public List<Choice> choices;

    public DialogChoice(string ID, string C1FolderName, string C1Emote, string C1DisplayName,
       string C2FolderName, string C2Emote, string C2DisplayName, List<Choice> Choices)
    {
        NodeID = ID;
        Char1FolderName = C1FolderName;
        Char1ProfileEmotion = C1Emote;
        Char1DisplayName = C1DisplayName;
        Char2FolderName = C2FolderName;
        Char2ProfileEmotion = C2Emote;
        Char2DisplayName = C2DisplayName;
        choices = Choices;
    }

    public override void DisplayDialog()
    {
        DialogController.Instance.displayDialogChoice("CharacterProfiles/" + Char1FolderName + "/" + Char1ProfileEmotion, Char1DisplayName,
            "CharacterProfiles/" + Char2FolderName + "/" + Char2ProfileEmotion, Char2DisplayName, choices);
    }
}
