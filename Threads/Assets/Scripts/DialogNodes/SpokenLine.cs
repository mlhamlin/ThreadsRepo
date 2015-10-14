using UnityEngine;
using System.Collections;

public class SpokenLine : DialogNode
{
    public string Char1FolderName;
    public string Char1ProfileEmotion;
    public string Char1DisplayName;
    public string Char2FolderName;
    public string Char2ProfileEmotion;
    public string Char2DisplayName;
    public string DialogLine;
    public bool Char1Speaking;
    public string nextNodeID;

    public SpokenLine(string ID, string C1FolderName, string C1Emote, string C1DisplayName, 
        string C2FolderName, string C2Emote, string C2DisplayName, string DialogText, bool C1Speaking, string nextID)
    {
        NodeID = ID;
        Char1FolderName = C1FolderName;
        Char1ProfileEmotion = C1Emote;
        Char1DisplayName = C1DisplayName;
        Char2FolderName = C2FolderName;
        Char2ProfileEmotion = C2Emote;
        Char2DisplayName = C2DisplayName;
        DialogLine = DialogText;
        Char1Speaking = C1Speaking;
        nextNodeID = nextID;
    }

    public override void DisplayDialog()
    {
        DialogController.Instance.displaySpokenLine("CharacterProfiles/" + Char1FolderName + "/" + Char1ProfileEmotion, Char1DisplayName,
            "CharacterProfiles/" + Char2FolderName + "/" + Char2ProfileEmotion, Char2DisplayName, DialogLine, Char1Speaking, nextNodeID);
    }
}
