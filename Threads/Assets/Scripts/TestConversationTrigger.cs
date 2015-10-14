using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestConversationTrigger : MonoBehaviour {

    public string start = "HuyuStart";

    public void StartConv()
    {
        DialogDictionary.GetNode(start).DisplayDialog();
    }
}
