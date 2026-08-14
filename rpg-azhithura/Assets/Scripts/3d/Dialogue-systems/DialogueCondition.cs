using System;

[Serializable]
public class DialogueCondition
{
    public StoryFlagData flagName;
    public bool expectedValue = true;

    public bool IsMet()
    {
        return StoryState.Instance.GetFlag(flagName.FlagName) == expectedValue;
    }
}