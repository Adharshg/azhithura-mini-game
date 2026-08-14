using UnityEngine;
using System.Collections.Generic;

public class StoryState : MonoBehaviour
{
    public static StoryState Instance;
    private Dictionary<string, bool> boolFlags = new();

    void Awake()
    {
        Instance = this;
    }

    public void SetFlag(string key, bool value)
    {
        boolFlags[key] = value;
    }

    public bool GetFlag(string key)
    {
        return boolFlags.ContainsKey(key) && boolFlags[key];
    }

    public void ToggleFlag(string key)
    {
        SetFlag(key, !GetFlag(key));
    }
}