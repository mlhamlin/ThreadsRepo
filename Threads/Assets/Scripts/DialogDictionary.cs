using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class DialogDictionary : UnitySingletonPersistent<DialogDictionary>
{
    Dictionary<string, DialogNode> nodes;
    public string fileName = "DialogMain";
    public bool load;
    JsonSerializerSettings settings;

    public void Start()
    {
        nodes = new Dictionary<string, DialogNode>();

        settings = new JsonSerializerSettings();
        settings.TypeNameHandling = TypeNameHandling.Objects;

        if(load)
        {
            DialogDictionary.LoadDictionary();
        }
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

    //Only for testing purposes.
    public static void SaveDictionary()
    {
        print(Application.persistentDataPath);

        string text = JsonConvert.SerializeObject(Instance.nodes, Instance.settings);

        File.WriteAllText(Application.persistentDataPath + "\\" + Instance.fileName + ".txt", text);
    }

    public static void LoadDictionary()
    {
        //print(Application.persistentDataPath);

        TextAsset DialogInfo = Resources.Load<TextAsset>("DialogFiles/" + Instance.fileName);
        //TextAsset DialogInfo = Resources.Load<TextAsset>("DialogFiles/DialogMain");

        //string text = File.ReadAllText(Application.persistentDataPath + "\\" + Instance.fileName + ".txt");

        Instance.nodes = JsonConvert.DeserializeObject<Dictionary<string, DialogNode>>(DialogInfo.text, Instance.settings);
    }
}
