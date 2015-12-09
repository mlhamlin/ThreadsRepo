using UnityEngine;
using System.Collections;

public class ConversationAmbush : MonoBehaviour {

    public string flag;
    public string NodeID;

    // if on entering this the flag is false force the conversation
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameStateDictionary.CheckFlag(flag))
        {
            DialogDictionary.GetNode(NodeID).DisplayDialog();
        }
    }
}
