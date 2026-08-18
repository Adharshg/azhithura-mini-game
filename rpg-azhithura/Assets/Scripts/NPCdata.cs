using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class NPCdata : MonoBehaviour
{
    public string CharacterName;
    public string HomeLocation;

    public List<Task> DailyTasks;
    public TaskType[] ApplicableTaskTypes;
}
