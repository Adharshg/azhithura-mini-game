using System;

[Serializable]
public class DialogueAction
{
    public StoryFlagData flagName;
    public bool value = true;

    public void Execute()
    {
        StoryState.Instance.SetFlag(flagName.FlagName, value);
    }
}