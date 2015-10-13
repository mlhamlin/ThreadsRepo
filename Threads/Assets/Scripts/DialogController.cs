using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class DialogController : UnitySingleton<DialogController> {

    public GameObject DialogWindow;

    public Image Char1Profile;
    public Text Char1Name;
    public Image Char1Pointer;

    public Image Char2Profile;
    public Text Char2Name;
    public Image Char2Pointer;

    public Text SpokenWords;
    public Button nextButton;

    public GameObject ChoiceScroll;
    public GameObject Content;
    public GameObject DialogOptionPrefab;

    public DialogNode currentNode;
    public DialogNode nextNode;

	// Use this for initialization
	void Start () {
        DialogDictionary.SetNode(new SpokenLine("L1", "Shawn", "sly", "Shawn", "Huyu", "neutral", "Huyu", "This is a test...", true, "L2"));
        DialogDictionary.SetNode(new SpokenLine("L2", "Shawn", "crazy", "Shawn", "Huyu", "annoyed", "Huyu", "a very circular test", true, "L3"));
        DialogDictionary.SetNode(new SpokenLine("L3", "Shawn", "crazy", "Shawn", "Huyu", "angry", "Huyu", "Haven't you already said that?", false, "L4"));
        DialogDictionary.SetNode(new SpokenLine("L4", "Shawn", "confused", "Shawn", "Huyu", "annoyed", "Huyu", "Have I? I can't seem to remember...", true, "L5"));
        DialogDictionary.SetNode(new SpokenLine("L5", "Shawn", "sad", "Shawn", "Huyu", "mad", "Huyu", "YES YOU HAVE!", false, "L6"));
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
        DialogDictionary.SetNode(new SpokenLine("L8b2", "Shawn", "pleased", "Shawn", "Huyu", "surprised", "Huyu", "Nope!", true, "L8b2"));
        DialogDictionary.SetNode(new SpokenLine("L8b3", "Shawn", "pleased", "Shawn", "Huyu", "annoyed", "Huyu", "darn it.", false, "L1"));
        choices.Add(c2);

        DialogChoice.Choice c3 = new DialogChoice.Choice();
        c3.playerChoiceLine = "Of Course not!";
        c3.flag = "SpokeOnce";
        c3.setFlagsFalse = new List<string>();
        c3.setFlagsTrue = new List<string>();
        c3.choiceResult = "L8c";
        DialogDictionary.SetNode(new SpokenLine("L8c", "Shawn", "neutral", "Shawn", "Huyu", "annoyed", "Huyu", "Why did I even ask...", false, "L1"));
        choices.Add(c3);

        DialogDictionary.SetNode(new DialogChoice("DC1", "Shawn", "confused", "Shawn", "Huyu", "scared", "Huyu", choices));

        //DialogDictionary.LoadDictionary();

        DialogNode start = DialogDictionary.GetNode("L1");
        start.DisplayDialog();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void displaySpokenLine(string C1ImagePath, string C1Name, string C2ImagePath, string C2Name, string Dialog, bool C1Speaking, string nextID)
    {
        Char1Profile.sprite = Resources.Load<Sprite>(C1ImagePath);
        Char1Name.text = C1Name;

        Char2Profile.sprite = Resources.Load<Sprite>(C2ImagePath);
        Char2Name.text = C2Name;

        SpokenWords.gameObject.SetActive(true);
        SpokenWords.text = Dialog;

        ChoiceScroll.SetActive(false);

        Char1Pointer.gameObject.SetActive(C1Speaking);
        Char2Pointer.gameObject.SetActive(!C1Speaking);

        nextNode = DialogDictionary.GetNode(nextID);
    }

    public void displayDialogChoice(string C1ImagePath, string C1Name, string C2ImagePath, string C2Name, List<DialogChoice.Choice> choices)
    {
        Char1Profile.sprite = Resources.Load<Sprite>(C1ImagePath);
        Char1Name.text = C1Name;

        Char2Profile.sprite = Resources.Load<Sprite>(C2ImagePath);
        Char2Name.text = C2Name;

        SpokenWords.gameObject.SetActive(false);

        ChoiceScroll.SetActive(true);
        for(int i = 0; i < Content.transform.childCount; i++)
        {
            Destroy(Content.transform.GetChild(i).gameObject);
        }
        Content.transform.DetachChildren();

        foreach(DialogChoice.Choice ch in choices)
        {
            if (GameStateDictionary.CheckFlag(ch.flag))
            {
                GameObject obj = Instantiate(DialogOptionPrefab);
                obj.transform.SetParent(Content.transform);
                DialogChoiceUI ChUI = obj.GetComponent<DialogChoiceUI>();
                ChUI.SetupChoice(ch);
            }
        }

        Char1Pointer.gameObject.SetActive(true);
        Char2Pointer.gameObject.SetActive(false);
    }

    public void excecuteEndDialog()
    {
        DialogWindow.SetActive(false);
    }

    public void NextButtonClicked()
    {
        currentNode = nextNode;
        currentNode.DisplayDialog();
    }
}
