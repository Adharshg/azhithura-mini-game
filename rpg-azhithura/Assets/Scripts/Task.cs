using System;
using UnityEngine;

public class Task : ScriptableObject
{
    public NPCdata npcdata { get; set; }
    public bool TaskDone { get; set; }
    public TaskType Type { get; set; }


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