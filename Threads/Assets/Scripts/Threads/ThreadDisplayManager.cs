using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThreadDisplayManager : UnitySingletonPersistent<ThreadDisplayManager> {

    private Dictionary<Character, List<Thread>> threads;

    private Character activeCharacter;

    public void Start()
    {
        threads = new Dictionary<Character, List<Thread>>();
        activeCharacter = Character.Aliya;
    }

    public static void setActiveCharacter(Character chr)
    {
        Instance.setCharacterThreadVisibility(Instance.activeCharacter, false);
        Instance.setCharacterThreadVisibility(chr, true);
        Instance.activeCharacter = chr;
    }

    private void setCharacterThreadVisibility(Character chr, bool vis)
    {
        List<Thread> charThreads;
        if(threads.TryGetValue(chr, out charThreads))
        {
            foreach(Thread thr in charThreads)
            {
                thr.setVisibility(vis);
            }
        }
    }

    public static void RegisterThread(Thread thr)
    {
        Instance.addThreadToChar(thr.character1, thr);
        Instance.addThreadToChar(thr.character2, thr);
    }

    private void addThreadToChar(Character chr, Thread thr)
    {
        List<Thread> charThreads;
        if(threads.TryGetValue(chr, out charThreads))
        {
            charThreads.Add(thr);
        }
        else
        {
            List<Thread> newCharThreads = new List<Thread>();
            newCharThreads.Add(thr);
            threads.Add(chr, newCharThreads);
        }
    }
}
