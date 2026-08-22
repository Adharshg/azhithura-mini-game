using System;
using UnityEngine;
using UnityEngine.UI;

public class Task : ScriptableObject
{
    public NPCdata npcdata { get; set; }
    public bool TaskDone { get; set; }
    public TaskType Type { get; set; }
    public Toggle TaskToggle { get; set; }

    int indexInlist;

    public void Init(NPCdata data)
    {
        npcdata = data;
        TaskDone = false;
        Type = npcdata.ApplicableTaskTypes[UnityEngine.Random.Range(0, npcdata.ApplicableTaskTypes.Length)];
    }

    public static Task Create(NPCdata data)
    {
        Task Instance = ScriptableObject.CreateInstance<Task>();
        Instance.Init(data);
        return Instance;
    }

    public void OnTaskDone()
    {
        TaskDone = true;
        TaskToggle.isOn = true;
    }

    public void CreateTaskOnList()
    {
        string TaskString = Type.ToString() + " - " + npcdata.CharacterName;
        TaskToggle = UIManager.Instance.AddTaskToList(TaskString);
    }

}

public enum TaskType
{
    CheckUp,
    Injection,
    ORS,
    RecordInfo,
    Remind,
    Steal,
    Tablet,
    Talk,
    UpdateRecords,
}