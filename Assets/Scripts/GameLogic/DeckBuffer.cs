using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeckBuffer
{
    public string DeckName;
    public List<int> cards;

    public static DeckBuffer CreatFormJson(string jsonString)
    {
        return JsonUtility.FromJson<DeckBuffer>(jsonString);
    }
}
