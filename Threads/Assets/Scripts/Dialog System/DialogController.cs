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

    public GameObject ChoiceScroll;
    public GameObject Content;
    public GameObject DialogOptionPrefab;

    public DialogNode currentNode;
    public DialogNode nextNode;

    private bool dialogActive;

    public bool Active
    {
        get { return dialogActive; }
        set
        {
            if (dialogActive != value)
            {
                DialogWindow.SetActive(value);
                dialogActive = value;
            }
        }
    }

	// Use this for initialization
	void Start () {
        DialogWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void displaySpokenLine(string C1ImagePath, string C1Name, string C2ImagePath, string C2Name, string Dialog, bool C1Speaking,
        List<string> FlagsToSetFalse, List<string> FlagsToSetTrue, string nextID)
    {
        Active = true;

        Char1Profile.sprite = Resources.Load<Sprite>(C1ImagePath);
        Char1Name.text = C1Name;

        Char2Profile.sprite = Resources.Load<Sprite>(C2ImagePath);
        Char2Name.text = C2Name;

        SpokenWords.gameObject.SetActive(true);
        SpokenWords.text = Dialog;

        ChoiceScroll.SetActive(false);

        Char1Pointer.gameObject.SetActive(C1Speaking);
        Char2Pointer.gameObject.SetActive(!C1Speaking);

        foreach(string s in FlagsToSetTrue)
        {
            GameStateDictionary.SetFlag(s, true);
        }

        foreach(string s in FlagsToSetFalse)
        {
            GameStateDictionary.SetFlag(s, false);
        }

        nextNode = DialogDictionary.GetNode(nextID);
    }

    public void displayDialogChoice(string C1ImagePath, string C1Name, string C2ImagePath, string C2Name, List<DialogChoice.Choice> choices)
    {
        Active = true;

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
        Active = false;
    }

    public void NextButtonClicked()
    {
        currentNode = nextNode;
        currentNode.DisplayDialog();
    }
}
