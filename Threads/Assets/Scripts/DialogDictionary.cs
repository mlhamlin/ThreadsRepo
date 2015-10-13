using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class DialogDictionary : UnitySingletonPersistent<DialogDictionary>
{
    Dictionary<string, DialogNode> nodes;
    public string fileName = "DialogTest";

    public void Start()
    {
        nodes = new Dictionary<string, DialogNode>();
    }

    public static DialogNode GetNode(string ID)
    {
        DialogNode value;
        if(Instance.nodes.TryGetValue(ID, out value))
        {
            return value;
        }
        //TODO: Replace with more helpful error
        return null;
    }

    public static void SetNode(DialogNode value)
    {
        Instance.nodes[value.NodeID] = value;
    }

    public static void SaveDictionary()
    {
        print(Application.persistentDataPath);

        string text = JsonConvert.SerializeObject(Instance.nodes);

        File.WriteAllText(Application.persistentDataPath + "\\" + Instance.fileName + ".txt", text);
    }

    public static void LoadDictionary()
    {
        //print(Application.persistentDataPath);

        string text = File.ReadAllText(Application.persistentDataPath + "\\" + Instance.fileName + ".txt");

        //TODO: Doesn't know what specific type each item is
        Instance.nodes = JsonConvert.DeserializeObject<Dictionary<string, DialogNode>>(text);
    }
}
